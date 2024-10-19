using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionLevel : MonoBehaviour
{
    private Animator transition;
    private PlayerMovements player;

    // Start is called before the first frame update
    void Start()
    {
        transition = GetComponent<Animator>();
    }

    public IEnumerator GameOver()
    {
        transition.SetTrigger("Start");
        while (transition.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            yield return null;
        }

        // Une fois l'animation terminée, recharger la scène
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
