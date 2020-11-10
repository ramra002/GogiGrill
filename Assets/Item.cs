using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Item : MonoBehaviour
{
    private Rigidbody rb;
    public Rigidbody Rb => rb;
    void Awake(){
        rb = GetComponent<Rigidbody>();
    }
}
