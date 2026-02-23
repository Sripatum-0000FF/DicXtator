using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject playerObject;
    [SerializeField] private SceneLoader sceneLoader;

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

        sceneLoader = GetComponent<SceneLoader>();
    }

    private void Start()
    {
        InitializeGame();
    }

    private void InitializeGame()
    {
        sceneLoader.LoadSceneAdditive("TestLoadScene");
    }
}