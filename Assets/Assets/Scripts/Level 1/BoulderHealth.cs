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
    private void FixedUpdate()
    {
        checkOutOfRange();
        kill();

    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void checkOutOfRange()
    {
        Vector3 pos = gameObject.GetComponent<Transform>().position;
        if (pos.x < -33.6 || pos.x > 58)
        {
            Destroy(gameObject);
        }
    }
    private void kill()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }



}
