using UnityEngine;

[CreateAssetMenu(fileName = "StampedPapers", menuName = "Papers/Stamped Paper")]
public class StampedPaperTemplate : PaperTemplate
{
    [SerializeField] private Sprite logo;
    
    public Sprite Logo => logo;
}
