using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour
{
    private UILayer ui;

    private void Start()
    {
        if (GameManager.Instance == null)
        {
            Debug.Log("GameManager not instance");
            return;
        }

        ui = GameObject.Find("UI").GetComponent<UILayer>();
        if (ui == null)
        {
            Debug.Log("Ui not instance");
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (GameManager.Instance.GetScore() >= 25)
            {
                GameManager.Instance.NextLevel();
                if (GameManager.Instance.GetIndexLevel() >= 1 &&
                    GameManager.Instance.GetIndexLevel() <= 3)
                {
                    SceneManager.LoadScene(GameManager.Instance.GetIndexLevel(), LoadSceneMode.Single);
                    
                }
                else
                {
                    SceneManager.LoadScene(0, LoadSceneMode.Single);
                    GameManager.Instance.SwitchUI(false);
                    GameManager.Instance.NewGamePlus();
                }
            }
            else if (GameManager.Instance.GetScore() < 25)
            {
                StartCoroutine(ui.AlertExitLevel(3));
            }
        }
          
    }

}
