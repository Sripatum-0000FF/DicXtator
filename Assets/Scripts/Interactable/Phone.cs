using UnityEngine;

public class Phone : Entity
{
    public Animator animator;
    public override void Interact(GameObject gameObject)
    {
        base.Interact(gameObject);
        animator = GetComponent<Animator>();
        animator.SetTrigger("Ring");
    }
}
