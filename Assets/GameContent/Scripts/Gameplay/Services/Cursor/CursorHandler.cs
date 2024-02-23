using UnityEngine;
using Zenject;

public class CursorHandler : IInitializable
{
    public void Initialize() => Visible(false);

    public void Visible(bool state)
    {
        Cursor.lockState = state ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = state;
    }
}
