using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Curtain : MonoBehaviour
{
    [SerializeField] private List<Transform> _blackouts = new List<Transform>();

    private void Start() => Hide();

    //TODO: Magic number!
    public void Show() 
    {
        foreach (Transform blackout in _blackouts)
            blackout.DOScaleY(1f, 0.5f);
    }

    //TODO: Magic number!
    public void Hide() 
    {
        foreach (Transform blackout in _blackouts)
        {
            if (blackout.gameObject.activeInHierarchy == false)
                blackout.gameObject.SetActive(true);

            blackout.DOScaleY(0f, 0.5f);
        }
    }
}
