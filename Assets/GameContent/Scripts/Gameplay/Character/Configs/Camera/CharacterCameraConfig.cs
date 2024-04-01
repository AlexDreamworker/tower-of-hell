using System;
using UnityEngine;

[Serializable]
public class CharacterCameraConfig
{
	[SerializeField, Range(0, 300f)] private float _xSensitivityEditor = 100f;
	[SerializeField, Range(0, 300f)] private float _ySensitivityEditor = 100f;

#pragma warning disable 0414
	[SerializeField, Range(0, 300f)] private float _xSensitivityBuild = 20f;
	[SerializeField, Range(0, 300f)] private float _ySensitivityBuild = 20f;
#pragma warning restore 0414

	[SerializeField, Range(-180f, 180f)] private float _xClampRotationMin = -60f;
	[SerializeField, Range(-180f, 180f)] private float _xClampRotationMax = 75f;
	[SerializeField, Range(0, 150f)] private float _normalFOV = 80f;

#if UNITY_EDITOR
	public float XSensitivity => _xSensitivityEditor;
	public float YSensitivity => _ySensitivityEditor;
#else
	public float XSensitivity => _xSensitivityBuild;
	public float YSensitivity => _xSensitivityBuild;
#endif

	public float XClampRotationMin => _xClampRotationMin;
	public float XClampRotationMax => _xClampRotationMax;
	public float NormalFOV => _normalFOV;
}