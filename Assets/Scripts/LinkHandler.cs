using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class LinkHandler : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TMP_Text contentText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnPointerClick(PointerEventData eventData)
    {
        int linkIndex = TMP_TextUtilities.FindIntersectingLink(contentText, eventData.position, eventData.pressEventCamera);

        if (linkIndex != -1)
        {
            TMP_LinkInfo linkInfo = contentText.textInfo.linkInfo[linkIndex];

            string linkText = linkInfo.GetLinkText();

            if (WordsList.Instance.Words.TryGetValue(linkText, out string replacementWord))
            {
                WordChanger(linkInfo, replacementWord);
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
    
}
