using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UILayer : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvas;
    [SerializeField] private TMP_Text score;
    [SerializeField] private Image hpImg;

    [SerializeField] private GameObject alertObj;
    [SerializeField] private TMP_Text alertMsg;

    //sprite for hp;
    public Sprite hp3;
    public Sprite hp2;
    public Sprite hp1;

    public void Start()
    {
        alertObj.SetActive(false);
    }
    

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.GetUI())
        {
            canvas.alpha = 0f;

        }
        else if (GameManager.Instance.GetUI())
        {
            canvas.alpha = 1f;
        }
        DisplayScore();
        DisplayHp();
        
    }


    void DisplayScore()
    {
        score.text = GameManager.Instance.GetScore() + " pts";
    }

   void DisplayHp()
    {
        switch (GameManager.Instance.GetHp())
        {
            case 3:
                hpImg.sprite = hp3;
                break;
            case 2:
                hpImg.sprite = hp2;
                break;
            default:
                hpImg.sprite = hp1;
                break;
        }
    }

    public void ReturnMain()
    {
        if (SceneManager.GetActiveScene().buildIndex >= 1 && SceneManager.GetActiveScene().buildIndex <= 3 )
        {
            GameManager.Instance.SwitchUI(false);
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
        
    }

    public IEnumerator AlertExitLevel(int seconds)
    {
        alertObj.SetActive(true);
        alertMsg.text = "You haven't enough points !";
        yield return new WaitForSeconds(seconds);
        alertObj.SetActive(false);
    }

    public void DisableAlert()
    {
        alertObj.SetActive(false);
        Debug.Log("///alertobj false/////");
    }
    
}
