using UnityEngine;

public class Lamp : Entity
{
    public override void Interact(GameObject gameObject)
    {
        base.Interact(gameObject);
        SoundManager.Instance.PlaySFX("LampClick", 1, 1);
    }
}
