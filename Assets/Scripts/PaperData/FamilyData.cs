using UnityEngine;

[CreateAssetMenu(fileName = "FamilyData", menuName = "Data/FamilyData")]
public class FamilyData : ScriptableObject
{
    static FamilyData _instance;

    public static FamilyData Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Resources.Load<FamilyData>("FamilyData");
            }
            return _instance;
        }
    }

    [SerializeField] private string[] familyName;
    public string[] FamilyName => familyName;
}
