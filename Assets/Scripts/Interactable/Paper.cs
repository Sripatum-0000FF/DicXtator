using System;
using UnityEngine;

public class Paper : Entity
{
    [SerializeField] private PaperTemplate paperTemplate;
    [SerializeField] private int templateIndex;
    
    public override void Interact(GameObject interactor)
    {
        PopupPaper();
    }
    
    private void PopupPaper()
    {
        switch (templateIndex)
        {
            case 0:
                GameManager.Instance.PaparData.SetUpNormalPaper(
                    paperTemplate.WrittenDate.GetDate(), 
                    paperTemplate.Text, 
                    paperTemplate.WriterName.GetCharacterName());
                break;
            case 1:
                
                break;
            case 2:
                
                break;
            default:
                print("Out of range");
                break;
        }
        GameManager.Instance.PaparData.ShowPaper(templateIndex);
    }
    
}
