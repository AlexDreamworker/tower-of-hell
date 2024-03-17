using UnityEngine;

public class CursorService : ICursorService
{
    //TODO: mobile input test
    public void Visible(bool status)
    {
        Cursor.lockState = status ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = status;
    }
}