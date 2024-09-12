using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreEndWave : MonoBehaviour
{
    [SerializeField] private Canvas canvasScoreWave;
    [SerializeField] private TMP_Text endWave;
    [SerializeField] private TMP_Text rankLife;

    [SerializeField] private TMP_Text rankEnergy;

    [SerializeField] private  TMP_Text perfect;

    private Castle_Live baseLife;

    private GestionScore points;

    private Stock_Ennergy energy;
    // Start is called before the first frame update
    void Start()
    {
        baseLife = GameObject.Find("Base").GetComponent<Castle_Live>();
        points = GameObject.Find("GestionScore").GetComponent<GestionScore>();
        energy = GameObject.Find("Stock_Energy").GetComponent<Stock_Ennergy>();
        string difficult = InstanceDifficult.Instance.GetDifficulty();
    }

    void DisplayWave(int wave)
    {
        endWave.text = "Fin Vague: " + wave;
    }

    void DisplayLifeRank(string difficult)
    {
        if (difficult == "easy")
        {
            switch (baseLife.GetHp())
            {
                case 5:
                    rankLife.text = "Life: S";
                    points.AddScore(500);
                    break;
                case >= 4:
                    rankLife.text = "Life: A";
                    points.AddScore(300);
                    break;
                case >= 3:
                    rankLife.text = "Life: B";
                    points.AddScore(100);
                    break;
                default:
                    rankLife.text = "Life: C";
                    points.AddScore(50);
                    break;
            }
        }
        else if (difficult == "hard")
        {
            switch (baseLife.GetHp())
            {
                case >= 4:
                    rankLife.text = "Life: S";
                    points.AddScore(500);
                    break;
                case >= 3:
                    rankLife.text = "Life: A";
                    points.AddScore(300);
                    break;
                case >= 2:
                    rankLife.text = "Life: B";
                    points.AddScore(100);
                    break;
                default:
                    rankLife.text = "Life: C";
                    points.AddScore(50);
                    break;
            }
        }
        
    }

    void DisplayEnergyRank(string difficult)
    {
        if (difficult == "easy")
        {
            switch (energy.GetEnergy())
            {
                case >= 16:
                    rankEnergy.text = "Energy: S";
                    points.AddScore(500);
                    break;
                case >= 12:
                    rankEnergy.text = "Energy: A";
                    points.AddScore(300);
                    break;
                case >= 8:
                    rankEnergy.text = "Energy: B";
                    points.AddScore(100);
                    break;
                default:
                    rankEnergy.text = "Energy: C";
                    points.AddScore(50);
                    break;            
            }
        }
        else if (difficult == "hard")
        {
            switch (energy.GetEnergy())
            {
                case >= 12:
                    rankEnergy.text = "Energy: S";
                    points.AddScore(500);
                    break;
                case >= 8:
                    rankEnergy.text = "Energy: A";
                    points.AddScore(300);
                    break;
                case >= 6:
                    rankEnergy.text = "Energy: B";
                    points.AddScore(100);
                    break;
                default:
                    rankEnergy.text = "Energy: C";
                    points.AddScore(50);
                    break;            
            }
        }
        
    }

    void DisplayPerfectWave(int wave, string difficult)
    {
        if (energy.GetEnergy() >= 16 && baseLife.GetHp() == 5 && difficult == "easy")
        {
            perfect.gameObject.SetActive(true);
            switch (wave)
            {
                case <= 4:
                    points.AddScore(1000);
                    break;
                case <= 8:
                    points.AddScore(5000);
                    break;
                default:
                    points.AddScore(10000);
                    break;
            }
        }
        else if (energy.GetEnergy() >= 12 && baseLife.GetHp() >= 4 && difficult == "hard")
        {
            perfect.gameObject.SetActive(true);
            switch (wave)
            {
                case <= 4:
                    points.AddScore(1000);
                    break;
                case <= 8:
                    points.AddScore(5000);
                    break;
                default:
                    points.AddScore(10000);
                    break;
            }
        }
    }

    public IEnumerator ScriptEndWave(int wave, string difficult)
    {
        canvasScoreWave.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        endWave.gameObject.SetActive(true);
        DisplayWave(wave);
        yield return new WaitForSeconds(1);
        rankLife.gameObject.SetActive(true);
        DisplayLifeRank(difficult);
        yield return new WaitForSeconds(1);
        rankEnergy.gameObject.SetActive(true);
        DisplayEnergyRank(difficult);
        yield return new WaitForSeconds(1);
        DisplayPerfectWave(wave, difficult);
    }

    public void DisactiveAllCanvas()
    {
        canvasScoreWave.gameObject.SetActive(false);
        endWave.gameObject.SetActive(false);
        rankLife.gameObject.SetActive(false);
        rankEnergy.gameObject.SetActive(false);
        perfect.gameObject.SetActive(false);
    }
}
