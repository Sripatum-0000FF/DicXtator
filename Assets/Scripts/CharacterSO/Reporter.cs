using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Reporter", menuName = "Character/Reporter")]
public class Reporter : Character
{
    [SerializeField] private bool customAlias = false;
    [SerializeField] private string characterAlias;

    public string CharacterAlias
    {
        get
        {
            if (characterAlias == String.Empty && CharacterFirstName != String.Empty && CharacterLastName != String.Empty)
            {
                string alias = $"{CharacterFirstName[0]}. {CharacterLastName}";
                return alias;
            }
            else return characterAlias;
            
        }
    }

    private void OnValidate()
    {
        if(!customAlias)
            GenerateCharacterAlias();
    }

    [ContextMenu("Generate Character Alias")]
    public void GenerateCharacterAlias()
    {
        if(CharacterFirstName == String.Empty) return;
        if (characterAlias != $"{CharacterFirstName[0]}. {CharacterLastName}")
        {
            characterAlias = $"{CharacterFirstName[0]}. {CharacterLastName}";
        }
    }

    public override string GetCharacterName()
    {
        if (characterAlias != String.Empty)
        {
            return characterAlias;
        }
        else return base.GetCharacterName();
    }
}
