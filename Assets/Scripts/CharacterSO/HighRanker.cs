using UnityEngine;

[CreateAssetMenu(fileName = "New HighRanker", menuName = "Character/HighRanker")]
public class HighRanker : Character
{
    [SerializeField] private Sprite characterStamp;
    [SerializeField] private Ranks rank;
    
    public Sprite CharacterStamp => characterStamp;

    public string GetRank()
    {
        switch (rank)
        {
            case Ranks.NormalRank :
                return "Normal Rank";
            case Ranks.BigRank :
                return "Big Rank";
            case Ranks.VeryBigRank :
                return "Very Big Rank";
            case Ranks.VeryVeryBigRank :
                return "Very Very Big Rank";
            case Ranks.GigaChadRank :
                return "Giga Chad Rank";
            default: return "This guy got executed";
        }
    }
}
