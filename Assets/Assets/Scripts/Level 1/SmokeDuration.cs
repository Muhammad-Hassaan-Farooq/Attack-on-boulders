using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeDuration : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem ps;
    float Duration;
    // Start is called before the first frame update
    void Start()
    {
        Duration = ps.duration + ps.startLifetime;
        Destroy(gameObject, Duration);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
