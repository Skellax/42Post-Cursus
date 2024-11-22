using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionLevel : MonoBehaviour
{
    private Animator transition;
   
    // Start is called before the first frame update
    void Start()
    {
        transition = GetComponent<Animator>();
        if (GameManager.Instance == null)
        {
            Debug.Log("GameManager not instance");
            return;
        }
    }

    public IEnumerator GameOver()
    {
        transition.SetTrigger("Start");
        while (transition.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            yield return null;
        }
        GameManager.Instance.DeleteTotalScore();
        GameManager.Instance.GameOver();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
