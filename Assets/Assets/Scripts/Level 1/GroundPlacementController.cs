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
    GameObject placementSmoke;
    [SerializeField]
    ParticleSystem placementParticles;
  

    
    GameModeSwitcher switcher;
    private int current_turret;

    private int placed;

    [SerializeField]
    Button btn;

    [SerializeField]
    Button confirmButton;

    [SerializeField]
    Button playBtn;

    //[SerializeField]
    //ToggleGroup tg;

    


    private void Start()
    {
       
        placed = 0;
        switcher = GameObject.FindGameObjectWithTag("GameSwitch").GetComponent<GameModeSwitcher>();
        switcher.start += onEnterGameMode;
        current_turret = -1;
        btn.onClick.AddListener(() =>
            selectTurret()
        );
        playBtn.interactable = false;
        confirmButton.onClick.AddListener(() =>
        {
            PlaceTurret();
        });
       
    }

    private void onEnterGameMode(object sender, EventArgs e)
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {


        
        if (currentPlaceableObject != null)
        {
            if (!IsPointerOverUIObject())
            {
                MoveCurrentObjectToMouse();
            }
            //RotateFromMouseWheel();
            //ReleaseIfClicked();
            
        }
    }



    private void selectTurret()
    {
        if(current_turret == 0)
        {
            current_turret = -1;
        }
        else
        {
            current_turret = 0;
        }
        HandleNewObjectHotkey();
    }



    private void HandleNewObjectHotkey()
    {



        

        

        //if (selected != null)
        //{
        //    Debug.Log(selected.name);
        //    switch (selected.name)
        //    {
        //        case ("Ballista"):
        //            current_turret = 0;
        //            break;
        //        case ("Garage"):
        //            current_turret = 1;
        //            break;
        //    }
        //}
        //if (selected == null)
        //{
        //    current_turret = -1;
        //    Debug.Log(selected);
        //}



        if (current_turret != -1)
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
            
            if (placed <2)
            {
                HandleNewObjectHotkey();
            }
            placed++;
        }
        
        if(placed == 3)
        {
            btn.interactable = false;
        }
    }

    private void PlaceTurret()
    {
        var smoke = Instantiate(placementSmoke,currentPlaceableObject.GetComponent<Transform>().position,Quaternion.Euler(-90,0,0));
        float duration = placementParticles.duration + placementParticles.startLifetime;
        Destroy(smoke, duration);
        currentPlaceableObject = null;
        
        if(placed < 2)
        {
            HandleNewObjectHotkey();

        }
        placed++;
        if (placed == 3)
        {
            btn.interactable = false;
            confirmButton.interactable = false;
            playBtn.interactable = true;
        }   
    }

    
}