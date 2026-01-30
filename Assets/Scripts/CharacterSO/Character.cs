using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character/Normal Character")]
public class Character : ScriptableObject
{
    [SerializeField] Sprite characterSprite;
    [SerializeField] string characterName;
    
    public Sprite CharacterSprite => characterSprite;
    public string CharacterName => characterName;
}
