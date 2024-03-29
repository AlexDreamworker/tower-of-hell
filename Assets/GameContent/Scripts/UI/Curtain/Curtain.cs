using System;
using System.Collections.Generic;
using UnityEngine;

public class Curtain : MonoBehaviour
{
	public event Action Completed;

	[SerializeField] private GameObject imageBlock;
	[SerializeField] private List<ScaleTweener> _tweeners = new List<ScaleTweener>();
	
	private void OnEnable()
	{
		foreach (var tweener in _tweeners)
			tweener.Completed += OnCompleted;
	}
	
	private void OnDisable()
	{
		foreach (var tweener in _tweeners)
			tweener.Completed -= OnCompleted;
	}

	public void Show() 
	{
		imageBlock.transform.Activate();
		
		foreach (var tweener in _tweeners)
		{
			tweener.Show();
			tweener.Play(new Vector3(1f, 0f, 1f), Vector3.one, 1f, default, default, default);
		}
	}

	public void Hide() 
	{	
		imageBlock.transform.Activate();
		
		foreach (var tweener in _tweeners)
		{
			tweener.Show();
			tweener.Play(true);
		}
	}
	
	private void OnCompleted()
	{
		imageBlock.transform.Deactivate();
		
		Completed?.Invoke();
	}
}