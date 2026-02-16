using UnityEngine;

public abstract class Paper : ScriptableObject
{
    [SerializeField] private Date date;
    [SerializeField] private Recipient recipient;
    [TextArea(5,15)] [SerializeField] private string content;
    [SerializeField] private Closing closing;
    [SerializeField] private CharacterData sender;  
    [SerializeField] private Sprite paperTexture;
    
    public Date Date => date;
    public Recipient Recipient => recipient;
    public string Content => content;
    public Closing Closing => closing;
    public CharacterData Sender => sender;
    public Sprite PaperTexture => paperTexture;
}
