using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class selectTurret : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler {

    private RectTransform rectTransform;
    private Vector2 initialPosition;
    [SerializeField] private Canvas canvas;
    public GameObject turret;
    public int cooldown;

    private bool cooldownActive = false;

    public TMP_Text countText;

    private bool canIDrop = false;

    private Transform zoneDrop;

    public Stock_Ennergy s;

    public TMP_Text alert;
    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
        initialPosition = rectTransform.anchoredPosition;
        alert.gameObject.SetActive(false);
        countText.gameObject.SetActive(false);
    }
   
    public void OnPointerDown(PointerEventData eventData){
        Debug.Log("OnPointerDown");
        if (turret.CompareTag("turret_A") && s.GetEnergy() < 3)
        {
            alert.gameObject.SetActive(true);
            StartCoroutine(HiddenAlert(1));
        }
        else if (turret.CompareTag("turret_B") && s.GetEnergy() < 2)
        {
            alert.gameObject.SetActive(true);
            StartCoroutine(HiddenAlert(1));
        }
        else if (turret.CompareTag("turret_C") && s.GetEnergy() < 1)
        {
            alert.gameObject.SetActive(true);
            StartCoroutine(HiddenAlert(1));
        }
    }

    public void OnDrag(PointerEventData eventData){
        Debug.Log("OnDrag");
        if (turret.CompareTag("turret_A") && s.GetEnergy() >= 3 && !cooldownActive)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
            
        }
        else if (turret.CompareTag("turret_B") && s.GetEnergy() >= 2 && !cooldownActive)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
        else if (turret.CompareTag("turret_C") && s.GetEnergy() >= 1 && !cooldownActive)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
        

    }

    public void OnEndDrag(PointerEventData eventData){
        Debug.Log("OnEndDrag");
        rectTransform.anchoredPosition = initialPosition;

        if (canIDrop && zoneDrop != null)
        {
            Turret existTurret = zoneDrop.GetComponentInChildren<Turret>();
            if (existTurret != null)
            {
                Destroy(existTurret.gameObject);
            }
            if (turret.CompareTag("turret_A") && s.GetEnergy() >= 3)
            {
                var copy = Instantiate(turret,zoneDrop.position,zoneDrop.rotation, zoneDrop);
                copy.transform.localScale = new Vector2(0.75f, 0.75f);
                s.SetEnergy(s.GetEnergy() - 3);
                cooldownActive = true;
                StartCoroutine(ActiveCoolDown(cooldown));
            }
            else if (turret.CompareTag("turret_B") && s.GetEnergy() >= 2)
            {
                var copy = Instantiate(turret,zoneDrop.position,zoneDrop.rotation, zoneDrop);
                copy.transform.localScale = new Vector2(0.75f, 0.75f);
                s.SetEnergy(s.GetEnergy() - 2);
                cooldownActive = true;
                StartCoroutine(ActiveCoolDown(cooldown));
            }
            else if (turret.CompareTag("turret_C") && s.GetEnergy() >= 1)
            {
                var copy = Instantiate(turret,zoneDrop.position,zoneDrop.rotation, zoneDrop);
                copy.transform.localScale = new Vector2(0.75f, 0.75f);
                s.SetEnergy(s.GetEnergy() - 1);
                cooldownActive = true;
                StartCoroutine(ActiveCoolDown(cooldown));
            }           
        }
        else
        {
            Debug.Log("Not Enough Energy !");
        }

    }


    public void OnBeginDrag(PointerEventData eventData){
    Debug.Log("OnBeginDrag");
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("drop"))
        {
            Debug.Log("test");
            canIDrop = true;
            zoneDrop = other.transform;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("drop"))
        {
            canIDrop = false;
            zoneDrop = null;
        }
        
    }

    private IEnumerator HiddenAlert(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        alert.gameObject.SetActive(false);
    }

    private IEnumerator ActiveCoolDown(int cooldown)
    {
        while (cooldownActive)
        {
            countText.gameObject.SetActive(true);
            for (int i = cooldown; i > 0; i--)
            {
                countText.text = i.ToString();
                yield return new WaitForSeconds(1);          
            }
            countText.gameObject.SetActive(false);
            cooldownActive = false;
        }
        

    }
}

