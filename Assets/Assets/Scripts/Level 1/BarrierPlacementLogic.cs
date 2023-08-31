using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BarrierPlacementLogic : MonoBehaviour
{
    [SerializeField]
    private GameObject Barrier;

    [SerializeField]
    Button placebtn;

    GameModeSwitcher switcher;

    [SerializeField]
    Text text;
    private float placableBarriers;

    [SerializeField]
    private Button confirmbtn;

    private GameObject currentBarrier;

    


    private float timer;

    private bool started;
    // Start is called before the first frame update
    void Start()
    {
        confirmbtn.gameObject.SetActive(false);
        placebtn.interactable = false;
        timer = 10;
        started = false;
        switcher = GameObject.FindGameObjectWithTag("GameSwitch").GetComponent<GameModeSwitcher>();
        switcher.start += startTimer;
        placebtn.onClick.AddListener(() =>
        {
            handlePlaceClick();
        });
        confirmbtn.onClick.AddListener(() =>
        {
            PlaceBarrier();
        });
        currentBarrier = null;
    }

    private void handlePlaceClick()
    {
        confirmbtn.gameObject.SetActive(true);
        currentBarrier = Instantiate(Barrier) ;
        currentBarrier.GetComponent<BoxCollider>().enabled = false;
        placableBarriers--;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            updateTimer();
        }
        
        handleButtonVisibility();
        if (currentBarrier != null)
        {
            if (!IsPointerOverUIObject())
            {
                MoveCurrentObjectToMouse();
            }
        }
    }
    private void updateTimer()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = 10;
            placableBarriers++;
        }
    }

    private void startTimer(object sender, EventArgs e)
    {
        started = true;
    }
    private void handleButtonVisibility()
    {
        if(placableBarriers > 0)
        {
            placebtn.interactable = true;
            text.enabled = false;
        }
        if(placableBarriers == 0)
        {
            placebtn.interactable = false;
            text.enabled = true;
        }
        text.text = Mathf.FloorToInt(timer).ToString();
    }
    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

    private void MoveCurrentObjectToMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            Vector3 position = hitInfo.point;
            position.y = 0;

            currentBarrier.transform.position = position;
            //currentPlaceableObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
        }
    }

    private void PlaceBarrier()
    {
        currentBarrier.GetComponent<BoxCollider>().enabled = true ;
        currentBarrier = null;
        confirmbtn.gameObject.SetActive(false);
    }
}
