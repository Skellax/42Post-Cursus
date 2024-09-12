using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEditor.Build.Content;
using UnityEngine;

public class InstanceDifficult : MonoBehaviour
{
    [SerializeField] private string difficulty = "easy";

    public static InstanceDifficult Instance;

    // Start is called before the first frame update

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void SetDifficulty(string newDifficulty)
    {
        difficulty = newDifficulty;
    }

    // Update is called once per frame
    
    public string GetDifficulty()
    {
        return this.difficulty;
    }
}
