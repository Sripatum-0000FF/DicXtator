using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PaperContent : MonoBehaviour
{
    [SerializeField] private GameObject normalPaper;
    [SerializeField] private TMP_Text date;
    [SerializeField] private TMP_Text recipient;
    [SerializeField] private TMP_Text content;
    [SerializeField] private TMP_Text closing;
    [SerializeField] private TMP_Text sender;
    [SerializeField] private Image paperTexture;
    
    [Header("PaperData")]
    [SerializeField] private Paper paperData;

    private int index;

    [ContextMenu("Change Paper Content")]
    public void ChangePaperContent()
    {
        if (paperData == null) return;
        
        IndexDeterminer();
        
        switch (index)
        {
            case 0:
                CleanPaperContent();
                
                date.text = paperData.Date.GetDate();
                recipient.text = paperData.Recipient.GetRecipient();
                content.text = paperData.Content;
                closing.text = paperData.Closing.GetClosingValue();
                sender.text = paperData.Sender != null ? paperData.Sender.GetCharacterName() : "";
                paperTexture.sprite = paperData.PaperTexture != null ? paperData.PaperTexture : Resources.Load("PaperTextures/PaperTexture", typeof(Sprite)) as Sprite;
                break;
        }
        
        OpenPaper();
    }

    public void OpenPaper()
    {
        switch (index)
        {
            case 0:
                normalPaper.SetActive(true);
                break;
            case 1:
                break;
            case 2:
                break;
        }
    }
    private void CleanPaperContent()
    {
        date.text = "";
        recipient.text = "";
        content.text = "";
        closing.text = "";
        sender.text = "";
        paperTexture.sprite = null;
    }
    
    private void IndexDeterminer()
    {
        switch (paperData)
        {
            case NormalPaper:
                index = 0;
                break;
            
        }
    }
}
