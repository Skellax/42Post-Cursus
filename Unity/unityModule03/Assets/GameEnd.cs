using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class GameEnd : MonoBehaviour
{
    [SerializeField] private Canvas gameEnd;
    [SerializeField] private  TMP_Text finalScore;

    [SerializeField] private TMP_Text sucessText;

    [SerializeField] private TMP_ColorGradient bronze;

    [SerializeField] private TMP_ColorGradient silver;

    [SerializeField] private TMP_ColorGradient gold;

    private GestionScore points;

    private Waves waves;


    // Start is called before the first frame update
    void Start()
    {
        points = GameObject.Find("GestionScore").GetComponent<GestionScore>();
        waves = GameObject.Find("Waves").GetComponent<Waves>();
        gameEnd.gameObject.SetActive(false);
        
    }

    public void GameIsEnd(bool reponse)
    {
        gameEnd.gameObject.SetActive(reponse);
    }

    void DisplaySuccess()
    {
        if (points.GetScore() > 1000 * waves.GetTotalWaves() && points.GetScore() < 1500 * waves.GetTotalWaves())
        {
            sucessText.colorGradientPreset = bronze;
            sucessText.text = "Congratulations you  have the bronze trophy :) !";
        }
        else if (points.GetScore() > 1500 * waves.GetTotalWaves() && points.GetScore() < 2000 * waves.GetTotalWaves())
        {
            sucessText.colorGradientPreset = silver;
            sucessText.text = "Congratulations you have the silver trophy :) !";
        }
        else if (points.GetScore() > 3000 * waves.GetTotalWaves())
        {
            sucessText.colorGradientPreset = gold;
            sucessText.text = "Congratulations you have the gold trophy :) !";
        }
        else
        {
            sucessText.colorGradientPreset = null;
            sucessText.color = Color.black;
            sucessText.text = "Too bad :(  Better Next Time !";
        }
        sucessText.ForceMeshUpdate();
    }

    void Display()
    {
        finalScore.text = "Score Final: " + points.GetScore().ToString();
        DisplaySuccess();
    }

    // Update is called once per frame
    void Update()
    {
        Display();
        
    }
}
