using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevel : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject spawnStart;
    private GameObject decor;

    private UILayer ui;


    // Start is called before the first frame update
    void Start()
    {
      ui = GameObject.Find("UI").GetComponent<UILayer>();
        if (ui == null)
        {
            Debug.Log("Ui not instance");
            return;
        }
      ui.DisableAlert();
      decor = GameObject.Find("Decor");
      GameObject newPlayer =  Instantiate(player, spawnStart.transform.position , Quaternion.identity);
      newPlayer.transform.SetParent(decor.transform);
        
    }
}
