using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonsAction : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject[] slotCards;
    public GameObject rotatedObject;
    public float rotationSpeed = 20f;
    bool rotate = false;
    bool onPressed;
    public float x, y, z ;
    public GameObject cardBack;
    public bool cardBackIsActive;
    public int timer;
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        cardBackIsActive = false;
    }

    // Update is called once per frame
    void Update()
    {
         
    }
    void FixedUpdate()
    {
        if (rotate == false)
            return;
 
        rotatedObject.transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
 
    public void OnFirstButtonClick()
    {
        if(slotCards[0].activeInHierarchy == true)
        {
            slotCards[0].SetActive(false);
        }
        else
        {
             slotCards[0].SetActive(true);
        }
    }
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        rotate = true;
    }
    public void OnPointerUp(PointerEventData pointerEventData)
    {
        rotate = false;
    }

    public void OnThirdButtonClick()
    {
        slotCards[2].transform.localScale = slotCards[2].transform.localScale + new Vector3(1*Time.deltaTime,1*Time.deltaTime, 0);
    }

    public void OnFourthButtonClick(Collider col)
    {
        /*
        if(onPressed)
        {
            slotCards[2].transform.localScale = slotCards[2].transform.localScale + new Vector3(1*Time.deltaTime,1*Time.deltaTime, 0);
        }
        */

        if(col.gameObject.tag == "ScaleOnPress")
        {
            slotCards[2].transform.localScale = slotCards[2].transform.localScale + new Vector3(1*Time.deltaTime,1*Time.deltaTime, 0);
        }
    }

    public void OnFifthButtonClick()
    {
        StartFlip();
    }
    public void StartFlip()
    {
        StartCoroutine(CalculateFlip());
    }

    public void Flip()
    {
        if(cardBackIsActive == true)
        {
            cardBack.SetActive(false);
            cardBackIsActive = false;
        }
        else
        {
            cardBack.SetActive(true);
            cardBackIsActive = true;
        }
    }
    IEnumerator CalculateFlip()
    {
        for(int i = 0; i < 180; i++)
        {
            yield return new WaitForSeconds(0.01f);
            transform.Rotate(new Vector3(x,y,z));
            timer++;

            if(timer == 90 || timer == -90)
            {
                Flip();
            }
        }
        timer = 0;
    }
}