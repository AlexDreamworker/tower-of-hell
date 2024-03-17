using UnityEngine;
using Zenject;

public class Detector : MonoBehaviour
{
    [SerializeField] private DetectorType _type;

    private DetectorReceiver _provider;

    [Inject]
    private void Construct(DetectorReceiver provider) 
    {
        _provider = provider;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Character character))
        {
            if (_type == DetectorType.Checkpoint) 
                TriggeredCheckpoint();
            else
                _provider.Triggered(_type);
        }
    }

    private void TriggeredCheckpoint() 
    {
        _provider.TriggeredCheckpoint(transform.position);
        gameObject.SetActive(false);
    }
}