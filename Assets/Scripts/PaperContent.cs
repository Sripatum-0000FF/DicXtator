using System;
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
    private Paper _previousPaperData;

    private Sprite _defaultPaperTexture;

    private void Awake()
    {
        _defaultPaperTexture = Resources.Load<Sprite>("PaperTextures/PaperTexture");
    }

    private void OnEnable()
    {
        Subscribe();
        ChangePaperContent();
    }

    private void OnDisable()
    {
        Unsubscribe();
    }

    private void OnValidate()
    {
        if (_previousPaperData != paperData)
        {
            Unsubscribe();
            Subscribe();
            ChangePaperContent();
        }
    }

    private void Subscribe()
    {
        if (paperData != null) paperData.OnDataChanged += ChangePaperContent;

        _previousPaperData = paperData;
    }

    private void Unsubscribe()
    {
        if (_previousPaperData != null)
            _previousPaperData.OnDataChanged -= ChangePaperContent;
    }
    
    [ContextMenu("Change Paper Content")]
    public void ChangePaperContent()
    {
        if (paperData == null) return;
        
        switch (paperData)
        {
            case NormalPaper normal:
                ApplyNormalPaper(normal);
                break;
            
        }
        
    }

    private void ApplyNormalPaper(NormalPaper paper)
    {
        CleanPaperContent();
                
        date.text = paper.Date.GetDate();
        recipient.text = paper.Recipient.GetRecipient();
        content.text = paper.Content;
        closing.text = paper.Closing.GetClosingValue();
        sender.text = paper.Sender != null ? paper.Sender.GetCharacterName() : "";
        
        if (_defaultPaperTexture == null)
            _defaultPaperTexture = Resources.Load<Sprite>("PaperTextures/PaperTexture");
        
        paperTexture.sprite = paper.PaperTexture != null 
            ? paper.PaperTexture : _defaultPaperTexture;
    }
    
    public void OpenPaper()
    {

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

}
