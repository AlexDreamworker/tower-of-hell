using System.Collections.Generic;
using UnityEngine;

public class Curtain : MonoBehaviour
{
    [SerializeField] private List<ScaleTweener> _tweeners = new List<ScaleTweener>();

    private void Start() => Hide();

    public void Show() 
    {
        foreach (var tweener in _tweeners)
        {
            tweener.Show();
            tweener.Play(new Vector3(1f, 0f, 1f), Vector3.one, 1f, default, default, default);
        }
    }

    public void Hide() 
    {
        foreach (var tweener in _tweeners)
        {
            tweener.Show();
            tweener.Play(true);
        }
    }
}