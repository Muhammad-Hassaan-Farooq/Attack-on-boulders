using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField]
    Button btn;

    [SerializeField]
    Button lvlBtn;
    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(() =>
            { Start_Game(); }
        );
        lvlBtn.onClick.AddListener(() =>
        {
            Open_Level_Selector();
        });
    }

    private void Open_Level_Selector()
    {
        SceneManager.LoadScene("Win_Scene-2", LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Start_Game()
    {
        SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
    }
}
