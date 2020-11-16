using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public int badLeaveCount = 0, goodLeaveCount = 0, customerCount = 1;
    public bool spawningCheck = false;
    public float waitTime = 5.0f;
    public UnityEngine.Events.UnityEvent callSpawn;
    // Start is called before the first frame update
    void Start()
    {
        waitTime = UnityEngine.Random.Range(5, 10);
        callSpawn.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        if(badLeaveCount == 3){
            Debug.Log("End Game, lose.");
            //exit
        }
        if(goodLeaveCount == 5){
            Debug.Log("Good Job!");
            //exit
        }
        if (spawningCheck == false && customerCount < 3){
            spawnCheck();
        }
    }
    
    public void badLeave(){
        badLeaveCount++;
        customerCount--;
        
    }

    public void goodLeave(){
        goodLeaveCount++;
        customerCount--;
    }

    public void spawnCheck(){
        GameLogic eventSys = (GameLogic) GameObject.Find("EventSystem").GetComponent<GameLogic>();
        spawningCheck = true;
        eventSys.StartCoroutine (eventSys.spawning());
        
    }

    public IEnumerator spawning(){
        GameObject spawner = GameObject.Find("CustomerSpawner");
        if (spawner.transform.childCount == 0){
            if(customerCount < 3){

                yield return new WaitForSeconds(waitTime);
            
                callSpawn.Invoke();
                customerCount++;
                spawningCheck = false;
                yield return null;
            }
        }
    }
}
