using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BarrierLogic : MonoBehaviour
{


    [SerializeField]
    GameObject explosion;
    [SerializeField]
    ParticleSystem ps;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boulder" ) 
        {
            Vector3 pos = gameObject.GetComponent<Transform>().position;
            if (other.GetComponent<Rolling>().size > 10)
            {
                
                var exp = Instantiate(explosion, pos, Quaternion.Euler(0, 0, 0));
                Destroy(exp, ps.duration + ps.startLifetime);
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
            else
            {
                var exp = Instantiate(explosion, pos, Quaternion.Euler(0, 0, 0));
                Destroy(exp, ps.duration + ps.startLifetime);
                Destroy(other.gameObject);
            }
        }
        
    }

    
}
