using DG.Tweening;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float sensX = 400;
    public float sensY = 400;

    public Transform orientation;

    private float xRotation;
    private float yRotation;

    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    public void DoFov(float endValue) 
    {
        GetComponent<Camera>().DOFieldOfView(endValue, 0.25f);
    }
}