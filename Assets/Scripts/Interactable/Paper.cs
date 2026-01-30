using System;
using UnityEngine;

public class Paper : Entity
{
    [SerializeField] private PaperTemplate paperTemplate;
    
    public override void Interact(GameObject interactor)
    {
        print("Paper Interact");
    }


    
    private void PopupPaper()
    {
        
    }
}
