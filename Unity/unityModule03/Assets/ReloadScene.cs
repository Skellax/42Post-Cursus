using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ReturnToMain()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
