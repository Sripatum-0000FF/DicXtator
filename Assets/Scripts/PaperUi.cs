using System;
using TMPro;
using UnityEngine;

[Serializable ]
public class NormalPaper
{
    public TMP_Text dateText;
    public TMP_Text contentText;
    public TMP_Text nameText;
}

public class PaperUi : MonoBehaviour
{
    [SerializeField] private GameObject[] paperTemplates;
    [SerializeField] private NormalPaper normalPaper;
    public void ShowPaper(int templateIndex)
    {
        paperTemplates[templateIndex].SetActive(true);
    }

    public void SetUpNormalPaper(string date, string content, string writerName)
    {
        normalPaper.dateText.text = date;
        normalPaper.contentText.text = content;
        normalPaper.nameText.text = writerName;
    }
}
