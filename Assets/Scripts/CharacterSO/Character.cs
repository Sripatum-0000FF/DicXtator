using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character/Normal Character")]
public class Character : ScriptableObject
{
    [SerializeField] Sprite characterSprite;
    [SerializeField] string characterFirstName;
    [SerializeField] string characterMiddleName;
    [SerializeField] string characterLastName;
    
    public Sprite CharacterSprite => characterSprite;
    public string CharacterFirstName => characterFirstName;
    public string CharacterMiddleName => characterMiddleName;
    public string CharacterLastName => characterLastName;

    public virtual string GetCharacterName()
    {
        if (characterMiddleName != string.Empty)
        {
            return $"{characterFirstName} {characterMiddleName} {characterLastName}";
        }
        else
        {
            return $"{characterFirstName} {characterLastName}";
        }
    }
}
