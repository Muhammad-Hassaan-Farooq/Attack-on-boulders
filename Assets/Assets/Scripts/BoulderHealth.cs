using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderHealth : Health 
{

    [SerializeField] Rolling rolling;
    [SerializeField] float SIZE_HEALTH_RATIO;
    // Start is called before the first frame update
    void Start()
    {
        health = rolling.size * SIZE_HEALTH_RATIO;
    }

  
}
