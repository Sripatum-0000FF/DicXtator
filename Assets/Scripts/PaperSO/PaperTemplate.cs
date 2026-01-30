using UnityEngine;

[System.Serializable]
public class Date
{
    public int day;
    public int month;
    public int year;

    public string GetDate()
    {
        return day + "/" + month + "/" + year;
    }
}

[CreateAssetMenu(fileName = "Paper", menuName = "Paper")]
public class PaperTemplate : ScriptableObject
{
    [SerializeField] private Date writtenDate;
    [TextArea]
    [SerializeField] private string text;
    [SerializeField] private Character writerName;
    
    public string Text => text;
    public Character WriterName => writerName;

    public Date WrittenDate => writtenDate;
}
