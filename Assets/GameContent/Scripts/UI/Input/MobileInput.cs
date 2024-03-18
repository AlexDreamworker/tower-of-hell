using UnityEngine;
using Zenject;

public class MobileInput : MonoBehaviour
{
    [SerializeField] private Context _context;

    //TODO: Change this!
    private IPauseService _pauseService;

    [Inject]
    private void Construct(IPauseService pauseService) 
        => _pauseService = pauseService;

    private void OnEnable()
        => _pauseService.PauseChanged += OnPauseChanged;

    private void OnDisable()
        => _pauseService.PauseChanged -= OnPauseChanged;

    private void OnPauseChanged(bool isPause) 
        => _context.SetActive(!isPause);
}