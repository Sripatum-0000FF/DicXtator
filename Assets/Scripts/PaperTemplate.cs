using UnityEngine;

[System.Serializable]
public class Date
{
    public int day;
    public int month;
    public int year;

    public string GetDate()
    {
        return "Date " + day + "/" + month + "/" + year;
    }
}

[CreateAssetMenu(fileName = "NormalPapers", menuName = "Papers/Normal Paper")]
public class PaperTemplate : ScriptableObject
{
    [SerializeField] private Date writtenDate;
    [TextArea]
    [SerializeField] private string text;
    [SerializeField] private Character writerName;
    [SerializeField] private Sprite customTexture;
    
    public string Text => text;
    public Character WriterName => writerName;

    public Date WrittenDate => writtenDate;
    public Sprite CustomTexture => customTexture;
}
