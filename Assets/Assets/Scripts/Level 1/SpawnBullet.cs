using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnBullet : MonoBehaviour
{
    // Start is called before the first frame update

    private int triggerZ = 4;
    [SerializeField] int updateRate;
    private int timer;
    [SerializeField] GameObject Bullets;
    private bool started;
    GameModeSwitcher switcher;

    [SerializeField]
    GameObject explosion;
    [SerializeField]
    ParticleSystem ps;
    void Start()
    {
        switcher = GameObject.FindGameObjectWithTag("GameSwitch").GetComponent<GameModeSwitcher>();
        timer = 0;
        started = false;
        switcher.start += startState;

    }


    private void FixedUpdate()
    {
        if (timer++ % updateRate == 0)
        {
            if (started)
            {
                spawn_bullet();
            }
        }
    }

    private void startState(object sender, EventArgs e)
    {
        started = true;
    }

    
    void spawn_bullet()
    {

        GameObject[] boulders = GameObject.FindGameObjectsWithTag("Boulder");
        if (boulders.Length != 0)
        {
            GameObject closestTarget = closestBoulder(boulders);
            if (gameObject.tag == "Projectile_spawner")
            {
                gameObject.GetComponent<Transform>().LookAt(closestTarget.GetComponent<Transform>());
            }

            Vector3 Projectilposition = gameObject.GetComponent<Transform>().position;
            if (gameObject.tag == "Vehicle_Spawner") Projectilposition[1] = 0;
            if (gameObject.tag == "Projectile_spawner") Projectilposition[1] = 6.7f;
            Instantiate(Bullets, Projectilposition, gameObject.GetComponent<Transform>().rotation);
        }
    }
    GameObject closestBoulder(GameObject[] boulders)
    {
        while (true)
        {
            boulders = GameObject.FindGameObjectsWithTag("Boulder");
            float closest_distance = 99999999999999999;
            GameObject closest = null;
            foreach (GameObject go in boulders)
            {
                try
                {
                    if (go.GetComponent<Transform>().position[2] - triggerZ < closest_distance)
                    {
                        closest_distance = go.GetComponent<Transform>().position[2] - triggerZ;
                        closest = go;
                    }
                }
                finally { }
            }
            if (closest != null)
                return closest;
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        Vector3 pos = gameObject.GetComponent<Transform>().position;
        var exp = Instantiate(explosion,pos,Quaternion.Euler(0,0,0));
        Destroy(exp, ps.duration + ps.startLifetime);
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
