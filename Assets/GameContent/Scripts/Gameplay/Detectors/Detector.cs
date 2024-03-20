using UnityEngine;
using Zenject;

public class Detector : MonoBehaviour
{
    [SerializeField] private DetectorType _type;

    private DetectorReceiver _receiver;

    [Inject]
    private void Construct(DetectorReceiver receiver) 
        => _receiver = receiver;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Character character))
            NotifyDetectorReceiver();
    }

    private void NotifyDetectorReceiver() 
    {
        if (_type != DetectorType.Checkpoint)
        {
            _receiver.Triggered(_type);
            return;
        }

        _receiver.TriggeredCheckpoint(transform.position);
        
        transform.Deactivate();
    }
}