using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{

    [SerializeField] GameObject Base;

    [SerializeField] GameObject collisionEffect;

    [SerializeField] GameObject lightDamageEffect;
    [SerializeField] GameObject heavyDamageEffect;

    private int damageStates = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Base.GetComponent<Health>().health -= other.GetComponent<Rolling>().size;
        Vector3 pos = other.GetComponent<Transform>().position;
        if (Base.GetComponent<Health>().health < 75 && damageStates == 0)
        {
            Vector3 smokePos = pos;
            smokePos[2] = 10;
            smokePos[1] = 37;
            Instantiate(lightDamageEffect, smokePos, Base.GetComponent<Transform>().rotation);
            damageStates++;
        }
        if (Base.GetComponent<Health>().health < 50 && damageStates == 1)
        {
            Vector3 smokePos = pos;
            smokePos[2] = 10;
            smokePos[1] = 37;
            Instantiate(lightDamageEffect, smokePos, Base.GetComponent<Transform>().rotation);
            damageStates++;
        }
        if (Base.GetComponent<Health>().health < 30 && damageStates == 2)
        {
            Vector3 smokePos = pos;
            smokePos[2] = 10;
            smokePos[1] = 37;
            smokePos[0] = 10;
            Instantiate(heavyDamageEffect, smokePos, Base.GetComponent<Transform>().rotation);
            damageStates++;
        }
        
        Instantiate(collisionEffect, pos, other.GetComponent<Transform>().rotation);
        Destroy(other.gameObject);
    }
}
