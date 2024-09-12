using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Stock_Ennergy : MonoBehaviour
{

    private int energy =  20;
    
    public GameObject count_text;
    // Start is called before the first frame update

    public void Awake()
    {
        StartCoroutine(RegenEnergy());
    }

    public void SetEnergy(int energy)
    {
        this.energy = energy;
        Display(energy);
    }

    public int GetEnergy()
    {
        return this.energy;
    }

    void Display(int energy)
    {
        count_text.GetComponent<TMP_Text>().text = energy.ToString();
    }
    // Update is called once per frame

    IEnumerator RegenEnergy()
    {
        while (true)
        {
            if (GetEnergy() < 20)
            {
                SetEnergy(energy + 1);
                Debug.Log("Energy Restored");

            }
            yield return new WaitForSeconds(20);
        }
    }

}

    
