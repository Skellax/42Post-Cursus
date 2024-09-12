using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Canvas pauseCanvas;
    [SerializeField] private TMP_Text returnGame;
    [SerializeField] private TMP_Text returnMain;

    private int select = 0;

    private EventSystem eventSystem;

    private bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        pauseCanvas.gameObject.SetActive(false);
        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Pause pressed !");
            if (!isPaused)
            {
                PauseGame();

            }
            else if (isPaused && select == 0)
            {
                ResumeGame();
            }
            else if (isPaused && select == 1)
            {
                Time.timeScale = 1.0f;
                UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");

            }
        }
        if (isPaused)
        {
            if (select == 0)
            {
                returnGame.fontSize = 2;
                returnMain.fontSize = 1;
            }
            else if (select == 1)
            {
                returnGame.fontSize = 1;
                returnMain.fontSize = 2;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                select = 1 - select;
            }
        }


        
    }

    void ResumeGame()
    {
        isPaused = false;
        pauseCanvas.gameObject.SetActive(false);
        eventSystem.enabled = true;
        Time.timeScale = 1.0f;
    }

    void PauseGame()
    {
        isPaused = true;
        pauseCanvas.gameObject.SetActive(true);
        eventSystem.enabled = false;
        Time.timeScale = 0f;
    }
}
