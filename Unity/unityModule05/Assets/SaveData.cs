using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveData : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("Hp"))
        {
            PlayerPrefs.SetInt("Score", 0);
            PlayerPrefs.SetInt("TotalScore", 0);
            PlayerPrefs.SetInt("NewGame", 0);
            PlayerPrefs.SetInt("LevelIndex", 1);
            PlayerPrefs.SetInt("Death", 0);
            PlayerPrefs.SetInt("Hp", 3);
            PlayerPrefs.SetString("LeafPath", "");

            PlayerPrefs.Save();

        }
    }
}
