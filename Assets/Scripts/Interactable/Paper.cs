using System;
using UnityEngine;

public class Paper : Entity
{
    [SerializeField] private PaperTemplate paperTemplate;
    private int templateIndex;
    private bool firstTime = false;
    
    public override void Interact(GameObject interactor)
    {
        TemplateIndexDeterminer();
        
        if (GameManager.Instance.PaparData.CheckIfPaperIsOpen(templateIndex))
        {
            GameManager.Instance.PaparData.ClosePaper(templateIndex);
        }
        else
        {
            PopupPaper();
        }

    }
    
    private void PopupPaper()
    {
        if (!firstTime)
        {
            firstTime = true;
        }
        else
        {
            GameManager.Instance.PaparData.ShowPaper(templateIndex);
            return;
        }
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
                ReporterPaperTemplate tempRep = paperTemplate as ReporterPaperTemplate;
                Reporter tempReporter = tempRep.WriterName as Reporter;
                if(tempRep == null) {print("tempRep is null"); return;}
                if (tempReporter == null) {print("tempReporter is null"); return;}

                if (paperTemplate.CustomTexture == null)
                {
                    GameManager.Instance.PaparData.SetUpReporterPaper(tempRep.WrittenDate.GetDate(), tempRep.Text,
                        tempRep.WriterName.GetCharacterName());
                }
                else
                {
                    GameManager.Instance.PaparData.SetUpReporterPaper(tempRep.WrittenDate.GetDate(), tempRep.Text,
                        tempRep.WriterName.GetCharacterName(),  tempRep.CustomTexture);
                }
                
                
                break;
            default:
                print("Out of range, dumbass");
                break;
        }
        GameManager.Instance.PaparData.ShowPaper(templateIndex);
    }

    private void TemplateIndexDeterminer()
    {
        if (paperTemplate as ReporterPaperTemplate)
        {
            templateIndex = 2;
        }
        else if (paperTemplate as StampedPaperTemplate)
        {
            templateIndex = 1;
        }
        else
        {
            templateIndex = 0;
        }
    }
    
}
