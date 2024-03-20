using UnityEngine;

public class BasePanel : MonoBehaviour
{
    [SerializeField] private GameObject _context;

    protected GameObject Context => _context;

    public void Show() => _context.transform.Activate();
    
    public void Hide() => _context.transform.Deactivate();
}