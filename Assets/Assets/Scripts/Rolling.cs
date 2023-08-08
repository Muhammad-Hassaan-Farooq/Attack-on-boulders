using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class Rolling : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Rigidbody rb;
    [SerializeField] Transform target;
    [SerializeField] float force;
    public int size;
    void Start()
    {   
        this.size = UnityEngine.Random.Range(4, 10);
        target.localScale = new Vector3(this.size,this.size,this.size);
        target.position += new Vector3(UnityEngine.Random.Range(-50, 51),0,0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(this.size);
        rb.AddForce(Vector3.back * force * (1 / target.GetComponent<Transform>().localScale[0]));
        //rb.AddForce(Vector3.back * force * (1 / this.size));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DeleteBoulder") 
             Destroy(gameObject); 
    }
}
