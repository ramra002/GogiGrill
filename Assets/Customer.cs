using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    //private GameObject[] tableList = GameObject.FindGameObjectsWithTag("Table");
    int tableNumber = 0;
    bool occupied = false;
    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        tableNumber = Random.Range(1, 16);
    }

    // Update is called once per frame
    void Update()
    {
        //yield return new WaitForSeconds(5);
        //this.transform.position(tableList[tableNumber].ObjectPosition.x, tableList[tableNumber].ObjectPosition.y + 10, tableList[tableNumber].ObjectPosition.z);
        
        /*while (tableList[tableNumber].isOccupied){
            tableNumber++;
            count++;

            if (count == 16){
                WaitForSecond(10);
                break;
            }
        }
        if (tableList[tableNumber].isOccupied == false){
            sit at table in chair 1;
        }*/
    
    }
}
