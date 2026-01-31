using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class LinkHandler : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TMP_Text contentText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        print("Pass");
        print(contentText.text);
        print(eventData.position);
        print(eventData.pressEventCamera);
        int linkIndex = TMP_TextUtilities.FindIntersectingLink(contentText, eventData.position, eventData.pressEventCamera);

        if (linkIndex != -1)
        {
            TMP_LinkInfo linkInfo = contentText.textInfo.linkInfo[linkIndex];
            string linkID = linkInfo.GetLinkID();

            if (linkID != null)
            {
                print("This work bro");
            }
        }
    }
}
