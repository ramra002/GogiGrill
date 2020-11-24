using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    public int badLeaveCount = 0, goodLeaveCount = 0, customerCount = 0;
    public bool spawningCheck = false;
    public float waitTime = 5.0f;
    public UnityEngine.Events.UnityEvent callSpawn;

    private int maxLostCount = 3, maxHappyCount = 5;

    private Text goodCount;
    private Text maxGoodCount;
    private Text badCount;
    private Text maxBadCount;
	
	private AudioSource LoseSound;
	private AudioSource WinSound;
	private AudioSource CustomerHappy;
	private AudioSource CustomerUnhappy;
	
    // Start is called before the first frame update
    void Start()
    {
        badLeaveCount = 0;
        goodLeaveCount = 0;
        customerCount = 0;
        waitTime = UnityEngine.Random.Range(4, 7);
        callSpawn.Invoke();
        customerCount++;

        goodCount = transform.Find("Canvas").Find("background1").Find("happyCount").GetComponent<Text>();
        badCount = transform.Find("Canvas").Find("background2").Find("lostCount").GetComponent<Text>();

        maxGoodCount = transform.Find("Canvas").Find("background1").Find("maxHappyCount").GetComponent<Text>();
        maxBadCount = transform.Find("Canvas").Find("background2").Find("maxLostCount").GetComponent<Text>();
    
		LoseSound = GetComponents<AudioSource>()[0];
		WinSound = GetComponents<AudioSource>()[1];
		CustomerHappy = GetComponents<AudioSource>()[2];
		CustomerUnhappy  = GetComponents<AudioSource>()[3];
	}

    // Update is called once per frame
    void Update()
    {
        goodCount.text = goodLeaveCount.ToString();
        badCount.text = badLeaveCount.ToString();
        maxGoodCount.text = maxHappyCount.ToString();
        maxBadCount.text = maxLostCount.ToString();

        if(badLeaveCount == maxLostCount){
            Debug.Log("End Game, lose.");
            //LOSE SOUND GOES HERE
			LoseSound.Play();
            SceneManager.LoadScene("Lose");
        }
        if(goodLeaveCount == maxHappyCount){
            Debug.Log("Good Job!");
            //WIN SOUND GOES HERE
			WinSound.Play();
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
        //CUSTOMER LEAVE SAD SOUND GOES HERE
		CustomerUnhappy.Play();
    }

    public void goodLeave(){
        GameLogic eventSys = (GameLogic) GameObject.Find("EventSystem").GetComponent<GameLogic>();
        eventSys.goodLeaveCount++;
        eventSys.customerCount--;
        Debug.Log("goodLeave");
        //CUSTOMER LEAVING HAPPY SOUND GOES HERE
		CustomerHappy.Play();
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
