using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Map_load : MonoBehaviour, IPointerUpHandler
{
    // Start is called before the first frame update

    [SerializeField] private int sceneIndex = 1;

    void Start()
    {
        
    }

    public void SetIndex( int index)
    {
        sceneIndex = index;
    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
        if (sceneIndex >= 0 && sceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(sceneIndex);

        }
        else
        {
            Debug.LogWarning("error index does not exits");
        }
        

    }
}
