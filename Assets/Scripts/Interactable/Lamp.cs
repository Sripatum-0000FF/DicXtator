using UnityEngine;

public class Lamp : Entity
{
    public GameObject lightGameObject;
    public override void Interact(GameObject gameObject)
    {   
        base.Interact(gameObject);
        SoundManager.Instance.PlaySFX("LampClick", 1, 1);
        lightGameObject.SetActive(!lightGameObject.activeSelf);
    }
}
