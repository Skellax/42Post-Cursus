using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GestionScore : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private int score = 0; 
    // Start is called before the first frame update
   
    void Display(int score)
    {
        scoreText.text = "Score: " + score + "pts";
    }

    public int GetScore()
    {
        return this.score;
    }

    public void AddScore(int addScore)
    {
        this.score += addScore;
    }

    // Update is called once per frame
    void Update()
    {
        Display(score);
        
    }
}
