using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManage : MonoBehaviour
{
    private void Start()
    {
        SceneManager.LoadScene("RealTableScene", LoadSceneMode.Additive);
    }
}
