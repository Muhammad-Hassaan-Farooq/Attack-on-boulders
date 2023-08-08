using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnBullet : MonoBehaviour
{
    // Start is called before the first frame update


    [SerializeField] int updateRate;
    private int timer;
    [SerializeField] GameObject Bullets;
    void Start()
    {
        timer = 0;
    }


    private void FixedUpdate()
    {
        if (timer++ % updateRate == 0)
        {
            GameObject[] boulders = GameObject.FindGameObjectsWithTag("Boulder");
            if (boulders.Length != 0)
            {
                Vector3 Projectilposition = gameObject.GetComponent<Transform>().position;
                if (gameObject.tag == "Vehicle") Projectilposition[1] = 0;
                Instantiate(Bullets, Projectilposition, gameObject.GetComponent<Transform>().rotation);
            }
        }
    }
}
