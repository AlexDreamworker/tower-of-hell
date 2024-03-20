using System.Collections.Generic;
using UnityEngine;

public static class TransfromExtensions
{
    public static void Activate(this Transform transform) 
        => transform.gameObject.SetActive(true);

    public static void Deactivate(this Transform transform) 
        => transform.gameObject.SetActive(false);

    public static void Destroy(this Transform transform)
        => Object.Destroy(transform.gameObject);

    public static void ResetTransformation(this Transform transform)
    {
        transform.position = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        transform.localScale = Vector3.one;
    }

    public static IEnumerable<Transform> Children(this Transform parent) 
    {
        foreach (Transform child in parent)
            yield return child;
    }

    public static void PerformActionOnChildren(this Transform parent, System.Action<Transform> action) 
    {
        for (int i = parent.childCount - 1; i >= 0; i--)
            action(parent.GetChild(i));
    }

    public static void DestroyChildren(this Transform parent)
        => parent.PerformActionOnChildren(child => Object.Destroy(child.gameObject));

    public static void EnableChildren(this Transform parent)
        => parent.PerformActionOnChildren(child => child.gameObject.SetActive(true));

    public static void DisableChildren(this Transform parent)
        => parent.PerformActionOnChildren(child => child.gameObject.SetActive(false));
}
