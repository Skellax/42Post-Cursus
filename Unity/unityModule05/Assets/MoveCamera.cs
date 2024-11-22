using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
     private GameObject player;
    [SerializeField] SpriteRenderer bg;

   
    // Update is called once per frame

    //This function find a gameobject player and if he found, the camera
    //move in the same time with the player


    void Update()
    {
        if( player == null)
        {
            player = GameObject.Find("player(Clone)");
            if (player == null)
            {
                Debug.Log("Gameobject player was not found!");
                return;
            }
        }
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        bg.transform.position = new Vector3(player.transform.position.x, bg.transform.position.y, bg.transform.position.z);
        
    }
}
