using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour

{

    [SerializeField]
    private Text text;
    [SerializeField]
    private float timer;
    private bool running;
    private bool over;


    public event EventHandler timeOver;
    // Start is called before the first frame update
    void Start()
    {
        
        running = false;
        over = false;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (running && !over)
        {
            timer-= Time.deltaTime;
        }
        if(timer <=0)
        {
            over = true;
            running = false;
            timer = 0;
            endTimer();
        }
        text.text = Mathf.FloorToInt(timer).ToString();
             
    }

    public void startTimer()
    {
        running = true;
        gameObject.SetActive(true);
    }

    private void endTimer()
    {
        timeOver?.Invoke(this, EventArgs.Empty);
    }
}
