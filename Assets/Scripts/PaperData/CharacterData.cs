using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Normal Character", menuName = "Data/Normal Character")]
public class CharacterData : ScriptableObject
{
    [SerializeField] private Sprite characterSprite;
    [SerializeField] private Roles role;
    [SerializeField] private string firstName;
    [SerializeField] private string middleName;
    [SerializeField] private string lastName;

    public int index = 0;
    public Sprite CharacterSprite => characterSprite;
    public string FirstName => firstName;
    public string MiddleName => middleName;
    public string LastName => lastName;
    
}
