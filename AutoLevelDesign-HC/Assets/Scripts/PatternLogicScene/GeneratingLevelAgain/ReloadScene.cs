using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    [SerializeField] private Scene scene;

    private void Awake()
    {
        scene = SceneManager.GetActiveScene();
    }


    public void ReGenerateScene()
    {
        Application.LoadLevel(scene.name);
    }
    
}
