using System;
using UnityEngine;

public class Paper : Entity
{
    [SerializeField] private PaperTemplate paperTemplate;
    private int templateIndex;
    
    public override void Interact(GameObject interactor)
    {
        TemplateIndexDeterminer();
        PopupPaper();
    }
    
    private void PopupPaper()
    {
        switch (templateIndex)
        {
            case 0:
                if (paperTemplate.CustomTexture == null)
                {
                    GameManager.Instance.PaparData.SetUpNormalPaper(
                        paperTemplate.WrittenDate.GetDate(), 
                        paperTemplate.Text, 
                        paperTemplate.WriterName.GetCharacterName());
                }
                else
                {
                    GameManager.Instance.PaparData.SetUpNormalPaper(
                        paperTemplate.WrittenDate.GetDate(), 
                        paperTemplate.Text, 
                        paperTemplate.WriterName.GetCharacterName(), paperTemplate.CustomTexture);
                }
                
                break;
            case 1:
                StampedPaperTemplate temp = paperTemplate as StampedPaperTemplate;
                HighRanker tempHighRanker = temp.WriterName as HighRanker;
                if (temp == null) {print("temp is null"); return;}
                if(tempHighRanker == null) {print("tempHigh is null"); return;}
                    
                if (paperTemplate.CustomTexture == null)
                {
                    GameManager.Instance.PaparData.SetUpStampedPaper(temp.WrittenDate.GetDate(), temp.Text
                        , $"{tempHighRanker.GetRank()} {temp.WriterName.GetCharacterName()}", temp.Logo, tempHighRanker.CharacterStamp);
                }
                else
                {
                    GameManager.Instance.PaparData.SetUpStampedPaper(temp.WrittenDate.GetDate(), temp.Text
                        , $"{tempHighRanker.GetRank()} {temp.WriterName.GetCharacterName()}", temp.Logo, tempHighRanker.CharacterStamp, temp.CustomTexture);
                }
                break;
            case 2:
                
                break;
            default:
                print("Out of range, dumbass");
                break;
        }
        GameManager.Instance.PaparData.ShowPaper(templateIndex);
    }

    private void TemplateIndexDeterminer()
    {
        if (paperTemplate as StampedPaperTemplate)
        {
            templateIndex = 1;
        }
        else
        {
            templateIndex = 0;
        }
    }
}
