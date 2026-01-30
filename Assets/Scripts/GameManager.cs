using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private PaperUi paperUi;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}
