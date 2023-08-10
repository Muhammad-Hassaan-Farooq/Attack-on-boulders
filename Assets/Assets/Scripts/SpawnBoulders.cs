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
    private int timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        switcher = GameObject.FindGameObjectWithTag("GameSwitch").GetComponent<GameModeSwitcher>();
        started = false;
        switcher.start += startState;
    }

    private void startState(object sender, EventArgs e)
    {
        started = true;
    }

    private void FixedUpdate()
    {if (timer++ % 100 == 0)
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
