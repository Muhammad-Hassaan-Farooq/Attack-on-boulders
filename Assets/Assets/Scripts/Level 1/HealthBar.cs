using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [SerializeField]
    private Health health;

    [SerializeField]
    Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health != null)
        {
            slider.value = health.health;
        }
        else
        {
            slider.value = 0;
        }
    }
}
