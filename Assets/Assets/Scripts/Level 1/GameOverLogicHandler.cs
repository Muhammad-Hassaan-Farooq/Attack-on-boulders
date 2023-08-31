using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverLogicHandler : MonoBehaviour
{

    [SerializeField]
    private GameObject house;

    [SerializeField]
    private GameObject WinScreen;

    [SerializeField]
    private GameObject LostScreen;

    [SerializeField]
    Timer timerScript;

    private bool lost = false;
    private bool won = false;
    private bool time = false;
    // Start is called before the first frame update
    void Start()
    {
        timerScript.timeOver += Won;
    }

    // Update is called once per frame
    void Update()
    {
        if(house == null && !lost && !won) {
            Destroyed();

        }
        else
        {
            if (time && !lost && !won) 
            {
                displayWin();
            }
        }

    }

    private void displayWin()
    {

        GameObject[] boulders = GameObject.FindGameObjectsWithTag("Boulder");
        if (boulders.Length == 0)
        {
            Instantiate(WinScreen);
            won = true;
        }

    }

    private void Won(object sender, EventArgs e)
    {
        
        time = true;
    }
    private void Destroyed()
    {
       
        Instantiate(LostScreen);
        lost = true;    
    }
}
