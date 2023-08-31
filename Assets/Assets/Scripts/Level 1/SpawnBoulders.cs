using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnBoulders : MonoBehaviour
{
    private bool started;
    GameModeSwitcher switcher;
    [SerializeField] GameObject Boulders;

    [SerializeField]
    Timer timerScript;
    private int timer;

    [SerializeField] int spawnRate;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        switcher = GameObject.FindGameObjectWithTag("GameSwitch").GetComponent<GameModeSwitcher>();
        started = false;
        switcher.start += startState;
        timerScript.timeOver += stopState;
    }

    private void startState(object sender, EventArgs e)
    {
        started = true;
    }

    private void stopState(object sender, EventArgs e)
    {
        
        started = false;
    }

    private void FixedUpdate()
    {if (timer++ % spawnRate == 0)
        {
            if (started)
            {
                spawn_boulder();
            }
        }
    }
    private void spawn_boulder()
    {
        Vector3 position = gameObject.GetComponent<Transform>().position;
        position[1] = 0;
        Instantiate(Boulders, position, gameObject.GetComponent<Transform>().rotation);
    }
}
