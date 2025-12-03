using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneHelper : MonoBehaviour
{
   
   public void Load(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }

    public void Load(string SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }
}
