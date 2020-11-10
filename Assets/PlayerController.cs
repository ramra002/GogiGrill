using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Transform itemSlot;

    private Item heldItem;

    public float speed = 20.0f;
    public float gravity = 9.8f;
    public float range = 2;
    
    public CharacterController controller;
    private Vector3 direction = Vector3.zero;
    private Vector3 rotation;
    private Collider newObject;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] objects = Physics.OverlapSphere(transform.position, range);

        if (controller.isGrounded){
            
            direction.x = Input.GetAxis("Horizontal");
            direction.z = Input.GetAxis("Vertical");
            direction = direction.normalized;

            direction = transform.TransformDirection(direction);

        }
        
        direction.y -= gravity * Time.deltaTime;
        
        controller.Move(direction * speed *  Time.deltaTime);

        if (Input.GetButtonDown("Fire1")){
            Debug.Log("press");
            if (heldItem){
                Drop(heldItem);
                Debug.Log("Drop");
            }
            else
            {
                foreach(Collider newObject in objects){
                    if (newObject.tag == "Food"){
                        if(newObject.gameObject.GetComponent<Item>()){
                            Item newItem = newObject.GetComponent<Item>();
                            Pickup(newItem);
                            Debug.Log("Pickup");
                        }
                    }
                }
            }
        }

    }

    void Pickup(Item item) {
        heldItem = item;

        item.Rb.isKinematic = true;
        item.Rb.velocity = Vector3.zero;
        item.Rb.angularVelocity = Vector3.zero;

        item.transform.SetParent(itemSlot);

        item.transform.localPosition = Vector3.zero;
        item.transform.localEulerAngles = Vector3.zero;
    }

    void Drop(Item item){
        heldItem = null;

        item.transform.SetParent(null);

        item.Rb.isKinematic = false;

        item.Rb.AddForce(item.transform.forward * 2, ForceMode.VelocityChange);
    }
}

