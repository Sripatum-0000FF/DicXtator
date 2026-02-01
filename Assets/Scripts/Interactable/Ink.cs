using UnityEngine;

public class Ink : Entity
{
    public Animator animator;
    public override void Interact(GameObject gameObject)
    {
        base.Interact(gameObject);
        animator = GetComponent<Animator>();
        animator.SetTrigger("InkClick");
    }
}
