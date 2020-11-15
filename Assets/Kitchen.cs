using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kitchen : MonoBehaviour
{
    public bool cooking = false;
    public float cookTimer = 10.0f;

    public Item FoodItem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cooking == true){
            cookTimer = cookTimer - Time.deltaTime;
           
            if (cookTimer <= 0){
                cooking = false;
                Item newFood = (Item) Instantiate(FoodItem, transform.position, transform.rotation);
                cookTimer = 10.0f;
            }
        }
    }

    void OnCollisionEnter(Collision col){
        if(col.gameObject.tag == "Menu"){
            if (cooking == false){
            Destroy(col.gameObject);
            cooking = true;
            }
            else{
                return;
            }
            
        }
    }
}
