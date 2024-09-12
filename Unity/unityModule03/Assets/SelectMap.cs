using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SelectMap : MonoBehaviour, IPointerUpHandler
{
    [SerializeField] private Canvas mapSelect;
    private bool activeWindow = false;
    // Start is called before the first frame update
    void Start()
    {
        mapSelect.gameObject.SetActive(false);
        
    }

    
    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("OnPointerUp");
        if (!activeWindow)
        {
            mapSelect.gameObject.SetActive(true);
            activeWindow = true;
        }
        else if (activeWindow)
        {
            mapSelect.gameObject.SetActive(false);
            activeWindow = false;
        }
        
        
    }
}
