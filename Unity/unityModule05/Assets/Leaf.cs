using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private int totalScore;
    [SerializeField] private string pos;
    void Start()
    {
        if (GameManager.Instance == null)
        {
            Debug.Log("GameManager not instance !");
            return;
        }
        if (GameManager.Instance.IsCollectedLeaf(pos))
        {
            Destroy(gameObject);
        }
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.CollectedLeaf(pos);
            GameManager.Instance.AddScore();
            StartCoroutine(Refrech());
        }
    }

    private IEnumerator Refrech()
    {
        yield return new WaitForSeconds(0.1f);
        GameManager.Instance.RecoverCollect();
        Destroy(gameObject);
    }
}


