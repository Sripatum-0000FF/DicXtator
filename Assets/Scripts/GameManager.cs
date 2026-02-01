using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private GameObject glassTubePrefab;
    [SerializeField] private Transform glassTubeParent;
    [SerializeField] private PaperUi paperUi;
    [SerializeField] private List<GameObject> paperPrefabs = new List<GameObject>();
    [SerializeField] private Transform paperSpawnpoint;
    public PaperUi PaparData => paperUi;

    private GameObject cacheObject;
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

    private void Start()
    {
        Invoke("InstantiateGlassTube", 2);
    }

    public void InstantiateGlassTube()
    {
        if (paperPrefabs.Count == 0)
        {
            print("Run out");
            SceneManagerSwap.Instance.ChangeScene("MainMenu");
        }
        else
        {
            Instantiate(glassTubePrefab, glassTubeParent.position, Quaternion.identity);
        }
        
    }

    public void GetPaper()
    {
        cacheObject = Instantiate(GetRandomItem(), paperSpawnpoint.position, paperSpawnpoint.rotation);
    }

    private GameObject GetRandomItem()
    {
        if (paperPrefabs.Count == 0)
        {
            return null;
        }
        
        int randomIndex = Random.Range(0, paperPrefabs.Count);
        GameObject randomItem = paperPrefabs[randomIndex];
        paperPrefabs.RemoveAt(randomIndex);
        return randomItem;
    }

    public void YeetPaper()
    {
        if(cacheObject == null) return;
        cacheObject.SetActive(false);
        Destroy(cacheObject);
        cacheObject = null;
    }
}
