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
        move();
    }

    void move()
    {
        if (gameObject.tag == "Vehicle")
        {
            Vector3 position = gameObject.GetComponent<Transform>().position;
            position[1] = 0;
            gameObject.GetComponent<Transform>().position = position;
        }
        if (gameObject.GetComponent<Transform>().position[2] > DeleteZMax || gameObject.GetComponent<Transform>().position[2] < DeleteZMin ||
            gameObject.GetComponent<Transform>().position[0] > DeleteXMax || gameObject.GetComponent<Transform>().position[0] < DeleteXMin)
            Destroy(gameObject);

        try
        {
            Vector3 distanceVector = this.boulder.GetComponent<Transform>().position - gameObject.GetComponent<Transform>().position;
            Vector3 MovementVector = (distanceVector / distanceVector.magnitude) * Velocity;  // multiply unit vector to velocity;
            last_vector = MovementVector;
            gameObject.GetComponent<Transform>().LookAt(this.boulder.GetComponent<Transform>());
            gameObject.GetComponent<Transform>().position += MovementVector;
            return;
        }
        catch (MissingReferenceException e)
        {

            gameObject.GetComponent<Transform>().position += last_vector;
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
