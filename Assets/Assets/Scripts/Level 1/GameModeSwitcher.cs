using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameModeSwitcher : MonoBehaviour
{
    public event EventHandler start;

    

    [SerializeField]
    private Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonPressed()
    {
        start?.Invoke(this, EventArgs.Empty);
        gameObject.SetActive(false);
        timer.startTimer();
    }

   
}
