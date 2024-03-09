using System;
using UnityEngine;

[Serializable]
public class CharacterCameraConfig
{
    [SerializeField, Range(0, 1000f)] private float _xSensitivity = 400f;
    [SerializeField, Range(0, 1000f)] private float _ySensitivity = 400f;
    [SerializeField, Range(-180f, 180f)] private float _xClampRotationMin = -90f;
    [SerializeField, Range(-180f, 180f)] private float _xClampRotationMax = 90f;
    [SerializeField, Range(0, 150f)] private float _normalFOV = 80f;

    public float XSensitivity => _xSensitivity;
    public float YSensitivity => _ySensitivity;
    public float XClampRotationMin => _xClampRotationMin;
    public float XClampRotationMax => _xClampRotationMax;
    public float NormalFOV => _normalFOV;
}
