using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "Paper", menuName = "Paper")]
public class PaperTemplate : ScriptableObject
{
    [SerializeField] private Vector3 date;
    [TextArea]
    [SerializeField] private string text;
    [SerializeField] private Character writerName;
    
    public Vector3 Date => date;
    public string Text => text;
    public Character WriterName => writerName;
}
