using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LavaHealth : BoulderHealth
{
    // Start is called before the first frame update

    [SerializeField] GameObject babyBoulder;


    // Start is called before the first frame update
    void Start()
    {
        health = 10;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (health <= 0)
        {
            splinter();
            Destroy(gameObject);
        }
        kill();
        checkOutOfRange();
    }

    private void splinter()
    {
        var child1 = Instantiate(babyBoulder, gameObject.GetComponent<Transform>().position, gameObject.GetComponent<Transform>().rotation);
        child1.GetComponent<Rigidbody>().AddForce(Vector3.left * 2);
        var child2= Instantiate(babyBoulder, gameObject.GetComponent<Transform>().position, gameObject.GetComponent<Transform>().rotation);
        child2.GetComponent<Rigidbody>().AddForce(Vector3.right * 2);

    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void checkOutOfRange()
    {
        Vector3 pos = gameObject.GetComponent<Transform>().position;
        if(pos.x<-33.6 || pos.x > 58)
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
