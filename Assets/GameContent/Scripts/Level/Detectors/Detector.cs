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
            _provider.Triggered(_type);
    }
}