using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GroundPlacementController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] placeableObjectPrefabs;

    private GameObject currentPlaceableObject;

    private float mouseWheelRotation;
    private int currentPrefabIndex = -1;
    [SerializeField]
    private ToggleGroup tg;

    private bool started;
    GameModeSwitcher switcher;


    private void Start()
    {
        switcher = GameObject.FindGameObjectWithTag("GameSwitch").GetComponent<GameModeSwitcher>();
        started = false;
        switcher.start += onEnterGameMode;
    }

    private void onEnterGameMode(object sender, EventArgs e)
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        HandleNewObjectHotkey();
        if (currentPlaceableObject != null)
        {
            MoveCurrentObjectToMouse();
            RotateFromMouseWheel();
            ReleaseIfClicked();
            
        }
    }

    private void HandleNewObjectHotkey()
    {


        Toggle selected = tg.GetFirstActiveToggle();

        int current_turret = -1;

        if (selected != null)
        {
            switch (selected.name)
            {
                case ("Ballista"):
                    current_turret = 0;
                    break;
                case ("Garage"):
                    current_turret = 1;
                    break;
            }
        }

        if(current_turret != -1)
        {
            if (PressedKeyOfCurrentPrefab(current_turret))
            {
                Destroy(currentPlaceableObject);
                currentPrefabIndex = -1;
            }
            else
            {
                if(currentPlaceableObject != null)
                {
                    Destroy(currentPlaceableObject);
                }
                currentPlaceableObject = Instantiate(placeableObjectPrefabs[current_turret]);
                currentPrefabIndex = current_turret;
            }
        }


        //for (int i = 0; i < placeableObjectPrefabs.Length; i++)
        //{
        //    if (Input.GetKeyDown(KeyCode.Alpha0 + 1 + i))
        //    {
        //        if (PressedKeyOfCurrentPrefab(i))
        //        {
        //            Destroy(currentPlaceableObject);
        //            currentPrefabIndex = -1;
        //        }
        //        else
        //        {
        //            if (currentPlaceableObject != null)
        //            {
        //                Destroy(currentPlaceableObject);
        //            }

        //            currentPlaceableObject = Instantiate(placeableObjectPrefabs[i]);
        //            currentPrefabIndex = i;
        //        }

        //        break;
        //    }
        //}
    }

    private bool PressedKeyOfCurrentPrefab(int i)
    {
        return currentPlaceableObject != null && currentPrefabIndex == i;
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
            
            currentPlaceableObject.transform.position = position;
            //currentPlaceableObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
        }
    }

    private void RotateFromMouseWheel()
    {
       
        mouseWheelRotation += Input.mouseScrollDelta.y;
        currentPlaceableObject.transform.Rotate(Vector3.up, mouseWheelRotation * 10f);
    }

    private void ReleaseIfClicked()
    {
        if (Input.GetMouseButtonDown(0)&& !IsPointerOverUIObject())
        {
            currentPlaceableObject = null;
        }
    }

    
}