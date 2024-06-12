using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public Transform finish;
    public Transform Claire;
    public Transform John;
    public Transform Thomas;

    public string nextSceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Claire != null && John != null && Thomas != null)
        {
            if (Claire.transform.position.z > finish.transform.position.z &&
            John.transform.position.z > finish.transform.position.z &&
            Thomas.transform.position.z > finish.transform.position.z)
            {
                if (SceneExist(nextSceneName))
                {
                    SceneManager.LoadScene(nextSceneName);
                    Debug.Log("Congratulations ! you're pass next stage");
                }
                else
                {
                    SceneManager.LoadScene(0);
                    Debug.Log("Congratulations !");
                }
            }
        }      
    }

    bool SceneExist(string sceneName)
    {
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
            string sceneNameInBuildSettings = System.IO.Path.GetFileNameWithoutExtension(scenePath);
            if (sceneName == sceneNameInBuildSettings)
            {
                return true;
            }

        }
        return false;
    }
}
