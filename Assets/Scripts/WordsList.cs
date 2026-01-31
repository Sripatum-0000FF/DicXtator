using System;
using System.Collections.Generic;
using UnityEngine;

public class WordsList : MonoBehaviour
{
    public static WordsList Instance;
    private Dictionary<string, string> _words = new Dictionary<string, string>()
    {
        {"kill","help"},{"loss",""},{"TestingWord","LongAssWord"}
    };
    
    public Dictionary<string, string> Words => _words;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
}
