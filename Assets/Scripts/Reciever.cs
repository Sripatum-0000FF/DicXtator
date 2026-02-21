using UnityEngine;

public class Reciever : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("Reciever Interact");
    }
}