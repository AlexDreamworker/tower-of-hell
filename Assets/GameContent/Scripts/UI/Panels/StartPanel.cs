using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class StartPanel : MonoBehaviour
{
    [Space]
    [SerializeField] private Context _context;
    [SerializeField] private Button _buttonStart;

    private Level _level;

    [Inject]
    private void Construct(Level level) 
        => _level = level;

    private void OnEnable()
    {
        _context.transform.localScale = Vector3.zero;
        _context.Show();

        _buttonStart.onClick.AddListener(StartCallback);
    }

    //TODO: Magic number!
    private void Start() 
        => _context.transform.DOScale(Vector3.one, 1f);

    private void OnDisable()
        => _buttonStart.onClick.RemoveListener(StartCallback);

    private void StartCallback()
    {
        _level.Start();
        _context.Hide();
    }
}