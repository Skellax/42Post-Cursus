using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Build.Content;

public class GameManager : MonoBehaviour
{

    private static GameManager instance = null;
    public static GameManager Instance => instance;


    //All playersprefs data;
    private string leafPath;
    private int score;
    private int hp;
    private int totalScore;
    private int death;
    private int indexStage;


    //bool to stop dmg continue

    bool isHited = false;

    // bool to stop double collect
    bool isCollected = false;

    // bool to display UI

    bool isUI = false;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.Log("Duplicate GameManager found. Destroying...");
            Destroy(this.gameObject);
            return;
        }
        else
            instance = this;
            DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("LeafPath"))
        {
            leafPath = PlayerPrefs.GetString("LeafPath");
        }
        if (PlayerPrefs.HasKey("Score"))
        {
            score = PlayerPrefs.GetInt("Score");
        }
        if (PlayerPrefs.HasKey("Hp"))
        {
            hp = PlayerPrefs.GetInt("Hp");
        }
        if (PlayerPrefs.HasKey("TotalScore"))
        {
            totalScore = PlayerPrefs.GetInt("TotalScore");
        }
        if (PlayerPrefs.HasKey("Death"))
        {
            death = PlayerPrefs.GetInt("Death");
        }
        if (PlayerPrefs.HasKey("LevelIndex"))
        {
            indexStage = PlayerPrefs.GetInt("LevelIndex");
        }
    }

    //function call in newGame 
    public void StartVariables()
    {
        if (PlayerPrefs.HasKey("LeafPath"))
        {
            leafPath = PlayerPrefs.GetString("LeafPath");
        }
        if (PlayerPrefs.HasKey("Score"))
        {
            score = PlayerPrefs.GetInt("Score");
        }
        if (PlayerPrefs.HasKey("Hp"))
        {
            hp = PlayerPrefs.GetInt("Hp");
        }
        if (PlayerPrefs.HasKey("TotalScore"))
        {
            totalScore = PlayerPrefs.GetInt("TotalScore");

        }
        if (PlayerPrefs.HasKey("Death"))
        {
            death = PlayerPrefs.GetInt("Death");
        }
        if (PlayerPrefs.HasKey("LevelIndex"))
        {
            indexStage = PlayerPrefs.GetInt("LevelIndex");
        }

    }

    //All function get;

    public int GetHp() => hp;
    public int GetScore() => score;
    public int GetIndexLevel() => indexStage;
    public int GetTotalScore() => totalScore;
    public int GetDeath() => death;
    public bool GetUI() => isUI;


    public void SwitchUI(bool reponse)
    {
        isUI = reponse;   
    }

    public bool IsCollectedLeaf(string pos)
    {
        return !string.IsNullOrEmpty(leafPath) && leafPath.Contains(pos + ",");
    }

    //Function register pos leaf

    public void CollectedLeaf(string pos)
    {
        if (!IsCollectedLeaf(pos))
        {
            leafPath += pos + ",";
            PlayerPrefs.SetString("LeafPath", leafPath);
            PlayerPrefs.Save();
        }
    }

    //Function reset HP, Score and LeafPath

    public void NextLevel()
    {
        hp = 3;
        leafPath = "";
        score = 0;
        indexStage++;
        PlayerPrefs.SetInt("Hp", hp);
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetString("LeafPath", leafPath);
        PlayerPrefs.SetInt("LevelIndex", indexStage);
        PlayerPrefs.Save();
    }

    public void NewGamePlus()
    {
        hp = 3;
        leafPath = "";
        score = 0;
        indexStage = 1;
        PlayerPrefs.SetInt("Hp", hp);
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetString("LeafPath", leafPath);
        PlayerPrefs.SetInt("LevelIndex", indexStage);
        PlayerPrefs.Save();
    }

    public void GameOver()
    {
        hp = 3;
        score = 0;
        leafPath = "";
        PlayerPrefs.SetInt("Hp", hp);
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetString("LeafPath", leafPath);
        PlayerPrefs.Save();
    }

    //Function add Score for each leaf collected

    public void AddScore()
    {
        if (!isCollected)
        {
            isCollected = true;
            score += 5;
            totalScore += 5;
            PlayerPrefs.SetInt("Score", score);
            PlayerPrefs.SetInt("TotalScore", totalScore);
            PlayerPrefs.Save();

        }  
    }

    public void DeleteTotalScore()
    {
        if (totalScore > 0)
            totalScore -= score;
        PlayerPrefs.SetInt("TotalScore", totalScore);
        PlayerPrefs.Save();
    }

    public void RecoverCollect()
    {
        isCollected = false;
    }

    //Function take dmg when the caterpillar hited !

    public void TakeDamage()
    {
        if (!isHited)
        {
            hp--;
            isHited = true;
            PlayerPrefs.SetInt("Hp", hp);
            PlayerPrefs.Save();
        }
    }

    //reuturn false for isHited

    public void HitedRecoverer()
    {
        isHited = false;
    }

    //Function increase the death count

    public void IncreaseDeath()
    {
        death++;
        PlayerPrefs.SetInt("Death", death);
        PlayerPrefs.Save();
    }
  
}
