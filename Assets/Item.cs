using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

[RequireComponent(typeof(Rigidbody))]
public class Item : MonoBehaviour
{
    private Rigidbody rb;
    
    public Rigidbody Rb => rb;

    public Transform target;

    public float range = 1;
    void Awake(){
        rb = GetComponent<Rigidbody>();
    }

    void Update(){
        Collider[] objects = Physics.OverlapSphere(transform.position, range);

        wallCheck(objects);
    }

    void wallCheck(Collider[] objects){
        foreach(Collider newObject in objects){
            if (newObject.tag == "Wall"){
                target = GameObject.Find("Player").transform;
                transform.position = (transform.position - target.position);
            }
        }
    }
}
