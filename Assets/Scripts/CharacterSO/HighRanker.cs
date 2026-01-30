using UnityEngine;

[CreateAssetMenu(fileName = "New HighRanker", menuName = "Character/HighRanker")]
public class HighRanker : Character
{
    [SerializeField] private Sprite characterStamp;
    [SerializeField] private Ranks rank;
    
    public Sprite CharacterStamp => characterStamp;
    public Ranks Rank => rank;
}
