using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class LinkHandler : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private string redactorText;
    [SerializeField] private TMP_Text contentText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnPointerClick(PointerEventData eventData)
    {
        int linkIndex = TMP_TextUtilities.FindIntersectingLink(contentText, eventData.position, eventData.pressEventCamera);

        if (linkIndex != -1)
        {
            TMP_LinkInfo linkInfo = contentText.textInfo.linkInfo[linkIndex];

            string linkText = linkInfo.GetLinkText();
            switch (linkInfo.GetLinkID())
            {
                case "ChangeWord":
                    
                    if (WordsList.Instance.Words.TryGetValue(linkText, out string replacementWord))
                    {
                        WordChanger(linkInfo, replacementWord);
                    }
                    break;
                case "Redacted":
                    Redactor(linkInfo);
                    break;
            }
           
        }
    }

    private void WordChanger(TMP_LinkInfo linkInfo, string word)
    {
        var textInfo = contentText.textInfo;
        var text = contentText.text;

        int firstChar = linkInfo.linkTextfirstCharacterIndex;
        int lastChar = firstChar + linkInfo.linkTextLength - 1;

        int startIndex = textInfo.characterInfo[firstChar].index;
        int endIndex = textInfo.characterInfo[lastChar].index + 1;

        int length = endIndex - startIndex;
        
        contentText.text = text.Remove(startIndex, length).Insert(startIndex, word);
        
        contentText.ForceMeshUpdate();
    }

    private void Redactor(TMP_LinkInfo linkInfo)
    {
        var textInfo = contentText.textInfo;
        var text = contentText.text;

        int firstChar = linkInfo.linkTextfirstCharacterIndex;
        int lastChar = firstChar + linkInfo.linkTextLength - 1;
        
        int startIndex = textInfo.characterInfo[firstChar].index;
        int endIndex = textInfo.characterInfo[lastChar].index + 1;
        
        int length = endIndex - startIndex;
        
        string redaction = new string(redactorText[0], linkInfo.linkTextLength);
        contentText.text = text.Remove(startIndex, length).Insert(startIndex, redaction);
        contentText.ForceMeshUpdate();

    }
    
}
