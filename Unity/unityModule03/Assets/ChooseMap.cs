using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChooseMap : MonoBehaviour, IPointerUpHandler
{
    [SerializeField] private int newIndex;
    [SerializeField] private string newDifficulty;
    [SerializeField] private Canvas mapCanvas;

    private Map_load newMap;
    // Start is called before the first frame update
    void Start()
    {
        newMap = GameObject.Find("Start").GetComponent<Map_load>();        
    }

    // Update is called once per frame
    public void OnPointerUp(PointerEventData eventData)
    {
        newMap.SetIndex(newIndex);
        InstanceDifficult.Instance.SetDifficulty(newDifficulty);
        mapCanvas.gameObject.SetActive(false);
    }
}
