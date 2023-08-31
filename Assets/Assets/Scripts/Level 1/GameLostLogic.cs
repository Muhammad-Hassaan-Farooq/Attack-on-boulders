using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLostLogic : MonoBehaviour
{

    [SerializeField]
    Button retry;

    [SerializeField]
    Button menu;    
    // Start is called before the first frame update
    void Start()
    {
        menu.onClick.AddListener(() =>
        returnToMain());

        retry.onClick.AddListener(() =>
        reload());
    }

    private void reload()
    {
        SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void returnToMain()
    {
        SceneManager.LoadScene("Start_Screen", LoadSceneMode.Single);
    }
}
