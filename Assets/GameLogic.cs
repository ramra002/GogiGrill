using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    public int badLeaveCount = 0, goodLeaveCount = 0, customerCount = 0;
    public bool spawningCheck = false;
    public float waitTime = 5.0f;
    public UnityEngine.Events.UnityEvent callSpawn;
    // Start is called before the first frame update
    void Start()
    {
        badLeaveCount = 0;
        goodLeaveCount = 0;
        customerCount = 0;
        waitTime = UnityEngine.Random.Range(4, 7);
        callSpawn.Invoke();
        customerCount++;
    }

    // Update is called once per frame
    void Update()
    {
        if(badLeaveCount == 3){
            Debug.Log("End Game, lose.");
            SceneManager.LoadScene("Lose");
        }
        if(goodLeaveCount == 5){
            Debug.Log("Good Job!");
            SceneManager.LoadScene("Win");
        }
        if (spawningCheck == false && customerCount < 4){
            spawnCheck();
        }
    }
    
    public void badLeave(){
        GameLogic eventSys = (GameLogic) GameObject.Find("EventSystem").GetComponent<GameLogic>();
        eventSys.badLeaveCount++;
        eventSys.customerCount--;
        Debug.Log("badLeave");
    }

    public void goodLeave(){
        GameLogic eventSys = (GameLogic) GameObject.Find("EventSystem").GetComponent<GameLogic>();
        eventSys.goodLeaveCount++;
        eventSys.customerCount--;
    }

    public void spawnCheck(){
        GameLogic eventSys = (GameLogic) GameObject.Find("EventSystem").GetComponent<GameLogic>();
        spawningCheck = true;
        eventSys.StartCoroutine (eventSys.spawning());
        
    }

    public IEnumerator spawning(){
        GameObject spawner = GameObject.Find("CustomerSpawner");
        if (spawner.transform.childCount == 0){
            if(customerCount < 4){

                yield return new WaitForSeconds(waitTime);
                waitTime = UnityEngine.Random.Range(4, 7);
                callSpawn.Invoke();
                customerCount++;
                spawningCheck = false;
                yield return null;
            }
        }
    }
}
