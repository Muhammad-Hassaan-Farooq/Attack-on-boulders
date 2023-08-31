using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int triggerZ = 4;
    [SerializeField] float Velocity;
    [SerializeField] float damage;
    private GameObject boulder;
    private Vector3 last_vector;
    private int DeleteZMax = 300;
    private int DeleteZMin = 0;
    private int DeleteXMax = 300;
    private int DeleteXMin = -300;
    // Start is called before the first frame update
    void Start()
    {
        this.boulder = closestBoulder(GameObject.FindGameObjectsWithTag("Boulder"));
        last_vector = new Vector3(0,0,Velocity);

    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (boulder != null)
        {
            move();
        }
        else
        {
            gameObject.GetComponent<Transform>().position += last_vector;
        }
    }

    void move()
    {
        
        if (gameObject.tag == "Vehicle")
        {
            Vector3 position = gameObject.GetComponent<Transform>().position;
            position[1] = 0;
            gameObject.GetComponent<Transform>().position = position;
        }
        Vector3 pos = gameObject.GetComponent<Transform>().position;
        if (pos[2] > DeleteZMax || pos[2] < DeleteZMin ||
            pos[0] > DeleteXMax || pos[0] < DeleteXMin)
            Destroy(gameObject);   

        try
        {
            Vector3 distanceVector = this.boulder.GetComponent<Transform>().position - pos;
            Vector3 MovementVector = (distanceVector / distanceVector.magnitude) * Velocity;  // multiply unit vector to velocity;
            last_vector = MovementVector;
            gameObject.GetComponent<Transform>().LookAt(this.boulder.GetComponent<Transform>());
            gameObject.GetComponent<Transform>().position += MovementVector;
            return;
        }
        catch (Exception e)
        {

            //gameObject.GetComponent<Transform>().position += last_vector;
            Destroy(gameObject);
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
            if(closest != null )
                return closest;
        }
    }

    

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Health>().health -= damage;
        Destroy(gameObject);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
