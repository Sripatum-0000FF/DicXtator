using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "Paper", menuName = "Paper")]
public class PaperTemplate : ScriptableObject
{
    [TextArea]
    [SerializeField] private string text;
    [SerializeField] private string writerName;
    
    public string Text => text;
    public string WriterName => writerName;
}
