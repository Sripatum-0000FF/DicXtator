using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class NormalPaper
{
    public TMP_Text dateText;
    public TMP_Text contentText;
    public TMP_Text nameText;
    public Image customTexture;
}

[Serializable]
public class StampPaper : NormalPaper
{
    public Image logoImage;
    public Image stampImage;
}

public class PaperUi : MonoBehaviour
{
    [SerializeField] private GameObject[] paperTemplates;
    [SerializeField] private NormalPaper normalPaper;
    [SerializeField] private StampPaper stampPaper;
    public void ShowPaper(int templateIndex)
    {
        paperTemplates[templateIndex].SetActive(true);
    }

    public void SetUpNormalPaper(string date, string content, string writerName)
    {
        normalPaper.dateText.text = date;
        normalPaper.contentText.text = content;
        normalPaper.nameText.text = writerName;
        
        if(Resources.Load<Sprite>("PaperTextures/PaperTexture"))
        {
            normalPaper.customTexture.sprite = Resources.Load<Sprite>("PaperTextures/PaperTexture");
        }
    }
    public void SetUpNormalPaper(string date, string content, string writerName, Sprite customTexture)
    {
        normalPaper.dateText.text = date;
        normalPaper.contentText.text = content;
        normalPaper.nameText.text = writerName;
        normalPaper.customTexture.sprite = customTexture;
    }

    public void SetUpStampedPaper(string date, string content, string writerName, Sprite logoImage, Sprite stampImage)
    {
        stampPaper.dateText.text = date;
        stampPaper.contentText.text = content;
        stampPaper.nameText.text = writerName;
        stampPaper.logoImage.sprite = logoImage;
        stampPaper.stampImage.sprite = stampImage;
        
        if(Resources.Load<Sprite>("PaperTextures/PaperTexture"))
        {
            stampPaper.customTexture.sprite = Resources.Load<Sprite>("PaperTextures/StampedPaperTexture");
        }
    }

    public void SetUpStampedPaper(string date, string content, string writerName, Sprite logoImage, Sprite stampImage,
        Sprite customTexture)
    {
        stampPaper.dateText.text = date;
        stampPaper.contentText.text = content;
        stampPaper.nameText.text = writerName;
        stampPaper.logoImage.sprite = logoImage;
        stampPaper.stampImage.sprite = stampImage;
        stampPaper.customTexture.sprite = customTexture;
    }
}
