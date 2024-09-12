using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Waves : MonoBehaviour
{
    
    [SerializeField] private int totalWaves;

    [SerializeField] private List<GenerateEnnemy> spawnList;


    [SerializeField] private TMP_Text wave_nb;

    private Castle_Live baseLife;

    private ScoreEndWave scoreEndWave;

    private EventSystem eventSystem;

    private GameEnd gameEnd;

    // Update is called once per frame

   public void Start()
   {
      eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
      baseLife = GameObject.Find("Base").GetComponent<Castle_Live>();
      gameEnd = GameObject.Find("GameEnd").GetComponent<GameEnd>();
      string difficult = InstanceDifficult.Instance.GetDifficulty();
      Debug.Log("diffculte: " + difficult);
      if (baseLife != null)
      {
         Debug.Log("baseLife is assigned");
      }
      scoreEndWave = GameObject.Find("CanvasScoreWave").GetComponent<ScoreEndWave>();
      if (scoreEndWave != null)
      {
         Debug.Log("scoreEndWave is assigned");
      }
      scoreEndWave.DisactiveAllCanvas();
      StartCoroutine(GestionWaves(difficult));
   }

    IEnumerator GestionWaves(string difficult)
    {
      
      for (int i = 1; i <= totalWaves; i++)
      {
         DesactivateAllSpawn(spawnList);
         wave_nb.text = "Wave: " + i.ToString(); //Affichage du numero de la vague !
         Debug.Log("Debut de la vague: " + i);        
         int spawnToActivate = Mathf.Min(i, spawnList.Count);
         Debug.Log("spawnToActivate: " + spawnToActivate);
         GenereRandomspwan(spawnList, spawnToActivate, i, difficult);
         yield return new WaitUntil(() => AllSpawnInInactive(spawnList));
         Debug.Log("Fin de la vague: " + i);
         eventSystem.enabled = false;
         StartCoroutine(scoreEndWave.ScriptEndWave(i, difficult));
         DesactivateAllSpawn(spawnList);
         yield return new WaitForSeconds(15);
         scoreEndWave.DisactiveAllCanvas();
         baseLife.Regene();
         eventSystem.enabled = true;
      }
      GameOver();          
   }

   public int RangeSpwan(int wave)
   {
      if (wave  <= 4)
      {
         return 4;
      }
      else if (wave <= 8)
      {
         return 8;
      }
      else
      {
         return spawnList.Count;
      }
   }
   
   public void GenereRandomspwan(List<GenerateEnnemy>ennemiesList, int count, int wave, string difficult)
   {
      List<int> usedIndexes = new List<int>();

    for (int i = 0; i < count; i++)
    {
        int randomIndex;
        do
        {
         randomIndex = Random.Range(0, RangeSpwan(wave));
        } while (usedIndexes.Contains(randomIndex));

        usedIndexes.Add(randomIndex);

        if (difficult == "easy" )
        {
            if (ennemiesList[randomIndex].GetIdEnnemi() == "Easy")
            {
               ennemiesList[randomIndex].SetNbEnnemies(wave + 1);
            }
            else if (ennemiesList[randomIndex].GetIdEnnemi() == "Medium")
            {
               ennemiesList[randomIndex].SetNbEnnemies(wave - 2);
            }
            else if (ennemiesList[randomIndex].GetIdEnnemi() == "Hard")
            {
               ennemiesList[randomIndex].SetNbEnnemies(wave - 5);
            }
            Debug.Log("spawn actif: " + ennemiesList[randomIndex].name);
            Debug.Log("nbres d'ennemies: " + ennemiesList[randomIndex].nbEnnemies);
            ennemiesList[randomIndex].ActiveSpwan(true);
        }          
      else if (difficult == "hard")
      {
         if (ennemiesList[randomIndex].GetIdEnnemi() == "Easy")
            {
               ennemiesList[randomIndex].SetNbEnnemies(wave + 2);
            }
            else if (ennemiesList[randomIndex].GetIdEnnemi() == "Medium")
            {
               ennemiesList[randomIndex].SetNbEnnemies(wave - 1);
            }
            else if (ennemiesList[randomIndex].GetIdEnnemi() == "Hard")
            {
               ennemiesList[randomIndex].SetNbEnnemies(wave - 3);
            }
            Debug.Log("spawn actif: " + ennemiesList[randomIndex].name);
            Debug.Log("nbres d'ennemies: " + ennemiesList[randomIndex].nbEnnemies);
            ennemiesList[randomIndex].ActiveSpwan(true);
         }
      }
   }


   public bool AllSpawnInInactive(List <GenerateEnnemy> spawnList)
   {
      foreach(var spawn in spawnList)
      {
         Debug.Log("spawn active: " + spawn.HasEnnemiesActive());
         if (!spawn.HasEnnemiesActive())
         {
            return false;
         }
      }
      return true;
   }

    public void DesactivateAllSpawn(List <GenerateEnnemy> spawnList)
    {
      foreach (var spwan in spawnList)
      {
         spwan.ActiveSpwan(false);
      }
    }

    void GameOver()
    {
        GameObject[] ennemies = GameObject.FindGameObjectsWithTag("ennemy");
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("bullet");
        GameObject[] turretsA = GameObject.FindGameObjectsWithTag("turret_A");
        GameObject[] turretsB = GameObject .FindGameObjectsWithTag("turret_B");
        GameObject[]turretsC = GameObject.FindGameObjectsWithTag("turret_C");
        GameObject[] spawns = GameObject.FindGameObjectsWithTag("Spawn");
        GameObject canvas = GameObject.Find("Canvas");

        canvas.gameObject.SetActive(false);

        foreach (GameObject bullet in bullets)
        {
            Destroy(bullet);
        }

        foreach (GameObject turretA in turretsA)
        {
            Destroy(turretA);
        }
         foreach (GameObject turretB in turretsB)
        {
            Destroy(turretB);
        }
         foreach (GameObject turretC in turretsC)
        {
            Destroy(turretC);
        }

        foreach (GameObject ennemy in ennemies)
        {
            Destroy(ennemy);
        }
        foreach (GameObject spanwn in spawns)
        {
            Destroy(spanwn);
        }
        gameEnd.GameIsEnd(true);
    }

    public int GetTotalWaves()
   {
      return (this.totalWaves);
   }
}



