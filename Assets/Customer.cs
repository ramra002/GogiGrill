using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customer : MonoBehaviour
{
    [SerializeField]
    public UnityEngine.Events.UnityEvent badLeave;
    [SerializeField]
    public UnityEngine.Events.UnityEvent seated;

    public bool menu = false, eating = false, order = false, isSeated = false, readyToEat = false, checkReady = false;
    public bool spawnToggle = false;
    private float maxTime = 60.0f;
    private float leaveTimer = 5.0f;
    private float menuTimer = 1.0f;
    private float eatTimer = 10.0f;
    private Text timerText;
    private Image timerBar;

    // Start is called before the first frame update
    void Awake()
    {
        leaveTimer = maxTime;
        eatTimer = UnityEngine.Random.Range(10, 20);
        menuTimer = UnityEngine.Random.Range(5, 10);
        timerText = transform.Find("Canvas").Find("Background").Find("timeBarText").GetComponent<Text>();
		timerBar = transform.Find("Canvas").Find("Background").Find("Image").Find("Image2").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
        timerText.text = Math.Round(leaveTimer).ToString();
		timerBar.fillAmount = leaveTimer / maxTime;

        if (menu == false && eating == false){
            leaveTimer = leaveTimer - Time.deltaTime;
        }
        if (menu == true){
            menuTimer = menuTimer - Time.deltaTime;

            if (menuTimer <= 0){
                menu = false;
                order = true;
            }
        }
        
        if (eating == true){
            eatTimer = eatTimer - Time.deltaTime;

            if (eatTimer <= 0){
                eating = false;
                checkReady = true;
            }
        }

        if(isSeated == true && spawnToggle == false){
            seated.Invoke();
            spawnToggle = true;
        }

        if (leaveTimer <= 0){
            Debug.Log("exit");
            badLeave.Invoke();
            Destroy(gameObject);
            
        }

    }

    void OnCollisionEnter(Collision col){
        if (col.gameObject.tag == "Food" && readyToEat == true){
            Destroy(col.gameObject);
            eating = true;
        }
    }

    public void takeOrder(){
        order = false;
    }
}
