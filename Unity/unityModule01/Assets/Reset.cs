using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    public int index;

    public GameObject gameover;
    // Start is called before the first frame update
    void Start()
    {
        if (gameover == null)
        {
            Debug.LogWarning("test");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameover != null &&!gameover.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(index);
            } 
        }
              
    }
}
