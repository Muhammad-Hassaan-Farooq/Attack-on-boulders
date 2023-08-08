using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnBoulders : MonoBehaviour
{

    [SerializeField] GameObject Boulders;
    private int timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    
    private void FixedUpdate()
    {if (timer++ % 100 == 0)
        {
            Vector3 position = gameObject.GetComponent<Transform>().position;
            position[1] = 0;
            Instantiate(Boulders, position, gameObject.GetComponent<Transform>().rotation);
        }
    }
}
