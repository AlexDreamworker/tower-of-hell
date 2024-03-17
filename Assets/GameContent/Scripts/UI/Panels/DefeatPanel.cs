using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class DefeatPanel : MonoBehaviour
{
    [Space]
    [SerializeField] private GameObject _context;

    [Space]
    [SerializeField] private Button _buttonContinue;

    private Level _level;

    [Inject]
    private void Construct(Level level) 
        => _level = level;

    private void OnEnable()
    {
        _context.SetActive(false);

        _level.Failed += OnLevelFailed;
        _buttonContinue.onClick.AddListener(ContinueCallback);
    }

    private void OnDisable()
    {
        _level.Failed -= OnLevelFailed;
        _buttonContinue.onClick.RemoveListener(ContinueCallback);
    }

    private void OnLevelFailed() 
    {
        _context.SetActive(true);

        //TODO: Change this!
        Time.timeScale = 0f;
    }

    private void ContinueCallback()
    {
        //TODO: Change this!
        Time.timeScale = 1f;

        _level.Restart();

        _context.SetActive(false);
    }
}
