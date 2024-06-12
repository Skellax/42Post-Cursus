using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


public class GameOverScript : MonoBehaviour
{
    public GameObject GameOverScreen;
    public GameObject Thomas;
    public GameObject Claire;
    public GameObject John;

    void Awake()
    {
        GameOverScreen.SetActive(false);
    }

    void Update()
    {
        if (John == null || Claire == null || Thomas == null)
        {
            GameOverScreen.SetActive(true);
        }
    }
}