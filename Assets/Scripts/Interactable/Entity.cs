using System;
using UnityEngine;

public class Entity : MonoBehaviour, IInteractable
{
    public virtual void Interact(GameObject gameObject)
    {
        print("Interact");
    }
}
