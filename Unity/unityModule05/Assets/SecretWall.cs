using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class SecretWall : MonoBehaviour
{
    [SerializeField] private Tilemap tileMap;
    private float secondSecretWall = 0.3f;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(WallReveled(secondSecretWall));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(WallHidden(secondSecretWall));
        }
    }



    private IEnumerator WallReveled(float seconds)
    {
        Color newColor;
        newColor = tileMap.color;
        newColor.a = 0.75f;
        tileMap.color = newColor;
        yield return new WaitForSeconds(seconds);
        newColor.a = 0.5f;
        tileMap.color = newColor;
        yield return new WaitForSeconds(seconds);
        newColor.a = 0.25f;
        tileMap.color = newColor;
        yield return new WaitForSeconds(seconds);
        newColor.a = 0f;
        tileMap.color = newColor;
    }

    private IEnumerator WallHidden(float seconds)
    {
        Color newColor;
        newColor = tileMap.color;
        newColor.a = 0.25f;
        tileMap.color = newColor;
        yield return new WaitForSeconds(seconds);
        newColor.a = 0.5f;
        tileMap.color = newColor;
        yield return new WaitForSeconds(seconds);
        newColor.a = 0.75f;
        tileMap.color = newColor;
        yield return new WaitForSeconds(seconds);
        newColor.a = 1f;
        tileMap.color = newColor;
    }
}
