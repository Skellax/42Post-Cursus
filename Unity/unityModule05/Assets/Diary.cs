using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.Rendering;
using Unity.VisualScripting;

public class Diary : MonoBehaviour
{
    [SerializeField] private TMP_Text totalScore;
    [SerializeField] private TMP_Text death;

    [SerializeField] private Image level2;
    [SerializeField] private Image level3;

    // Start is called before the first frame update
    void Start()
    {   
    }

    // Update is called once per frame
    void Update()
    {
        DisplayStats();
        DisplayLevel();
        
    }

    private void DisplayStats()
    {
        totalScore.text = GameManager.Instance.GetTotalScore().ToString();
        death.text = GameManager.Instance.GetDeath().ToString();
    }

    private void DisplayLevel()
    {
        switch (GameManager.Instance.GetIndexLevel())
        {
            case 2:
                level2.color = Color.white;
                break;
            case 3 :
                level3.color = Color.white;
                level2.color = Color.white;
                break;
            default :
                level2.color = Color.red;
                level3.color = Color.red;
                break;

        }
    }

    public void ReturnMain()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
