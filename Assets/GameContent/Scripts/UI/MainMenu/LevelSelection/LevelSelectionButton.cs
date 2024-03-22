using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelSelectionButton : MonoBehaviour
{
	public event Action<SceneID> Click;

	[SerializeField] private SceneID _sceneID;

	private Button _button;

	private void Awake() => _button = GetComponent<Button>();

	private void OnEnable() => _button.AddListener(OnClick);

	private void OnDisable() => _button.RemoveListener(OnClick);

	private void OnClick() => Click?.Invoke(_sceneID);
}