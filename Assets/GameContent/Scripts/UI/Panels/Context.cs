using UnityEngine;

public class Context : MonoBehaviour
{
    public void Show() => gameObject.SetActive(true);
    public void Hide() => gameObject.SetActive(false);
    public void SetActive(bool isActive) => gameObject.SetActive(isActive);
}
