using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    int badLeaveCount = 0, goodLeaveCount = 0, customerCount = 1;
    float spawnWait = 20.0f;
    public UnityEngine.Events.UnityEvent callSpawn;
    // Start is called before the first frame update
    void Start()
    {
        callSpawn.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        if(badLeaveCount == 3){
            Debug.Log("End Game");
            //exit
        }
        if(goodLeaveCount == 5){
            Debug.Log("Good Job!");
            //exit
        }
    }
    
    public void badLeave(){
        badLeaveCount++;
    }

    public void goodLeave(){
        goodLeaveCount++;
    }

    public void upCust(){
        customerCount++;
    }

    public void downCust(){
        customerCount--;
    }

    public void spawnCheck(){
        GameLogic eventSys = (GameLogic) GameObject.Find("EventSystem").GetComponent<GameLogic>();
        eventSys.StartCoroutine (eventSys.spawning());
    }

    public IEnumerator spawning(){
        GameObject spawner = GameObject.Find("CustomerSpawner");
        if (spawner.transform.childCount == 0){
            if(customerCount < 3){
                yield return new WaitForSeconds(5.0f);
            
                callSpawn.Invoke();
                customerCount++;
                yield return null;
            }
        }
    }
}
