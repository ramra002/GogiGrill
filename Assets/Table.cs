using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col){
        Customer temp;
        if(col.gameObject.tag == "Food"){
            if(transform.Find("Chair 1").Find("Seat").childCount > 0){
                temp = (Customer) transform.Find("Chair 1").Find("Seat").GetChild(0).GetComponent<Customer>();
                if (temp.readyToEat == true){
                    Destroy(col.gameObject);
                    temp.readyToEat = false;
                    temp.eating = true;
                    //CUSTOMER RECIEVING FOOD SOUND GOES HERE
                }
            }
        }
    }
}
