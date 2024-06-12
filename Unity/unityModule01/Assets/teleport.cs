using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    public Transform target;
    private CharacterController player;

     private void OnTriggerEnter(Collider other)
     {
          player = other.gameObject.GetComponent<CharacterController>();
          player.enabled = false;
          other.gameObject.transform.position = target.position;
          player.enabled = true;
     }
}
