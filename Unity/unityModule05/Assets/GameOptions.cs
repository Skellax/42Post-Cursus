using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UIElements;

public class GameOptions : MonoBehaviour
{

    [SerializeField] private TMP_Text alertMsg;
    [SerializeField] private GameObject alertObj;

    //Function for button new Game
    public void NewGame()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();

        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("TotalScore", 0);
        PlayerPrefs.SetInt("NewGame", 1);
        PlayerPrefs.SetInt("LevelIndex", 1);
        PlayerPrefs.SetInt("Death", 0);
        PlayerPrefs.SetInt("Hp", 3);
        PlayerPrefs.SetString("LeafPath", "");

        //Save the playerprefs
        PlayerPrefs.Save();
        //Load Stage 1 Scene

        GameManager.Instance.StartVariables();

    if (GameManager.Instance != null)
        {
            GameManager.Instance.SwitchUI(true);
        }
        
        SceneManager.LoadScene(PlayerPrefs.GetInt("LevelIndex"), LoadSceneMode.Single);
        

    }

    public void Continue()
    {
        if (PlayerPrefs.GetInt("NewGame") == 1)
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.SwitchUI(true);
            }
            
            SceneManager.LoadScene(PlayerPrefs.GetInt("LevelIndex"), LoadSceneMode.Single);
            
        }
        else
        {
            StartCoroutine(AlertText(3));

        }
    }

    public void DiaryMain()
    {
        SceneManager.LoadScene(4, LoadSceneMode.Single);
    }

    public void DeleteSave()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Delete  all UsersPrefs");
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("TotalScore", 0);
        PlayerPrefs.SetInt("NewGame", 0);
        PlayerPrefs.SetInt("LevelIndex", 1);
        PlayerPrefs.SetInt("Death", 0);
        PlayerPrefs.SetInt("Hp", 3);
        PlayerPrefs.SetString("LeafPath", "");

        //Save the playerprefs
        PlayerPrefs.Save();
        

        GameManager.Instance.StartVariables();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }


    IEnumerator AlertText(int seconds)
    {
        alertObj.SetActive(true);
        alertMsg.text = "No save, start a new Game !";
        yield return new WaitForSeconds(seconds);
        alertObj.SetActive(false);
    }
}
