using UnityEngine;
using Zenject;

public class CursorService : ICursorService, IInitializable
{
    public void Initialize() => Visible(false);

    public void Visible(bool status)
    {
        Cursor.lockState = status ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = status;
    }
}
