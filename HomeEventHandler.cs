using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HomeEventHandler : MonoBehaviour {
    public GameManager gameManager;
    public TimerHander timerHander;
    public Animator mask_animator;
    public Animator log_animator;
    public Player_controller playerCtr;
    float delay = 6.5f;
    public float delayTimer = 6.6f;
    string currentEventName = "None";
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gameManager.isGaming == false)
        {
            return;
        }
        if (delayTimer < delay)
        {
            this.delayTimer += Time.deltaTime;
            if (this.delayTimer >= this.delay)
            {
                switch (this.currentEventName)
                {
                    case "pc":
                        pcEvent_result();
                        break;
                    case "frontDoor":
                        frontDoorEvent_result();
                        break;
                    case "backDoor":
                        backDoorEvent_result();
                        break;
                    case "2floor":
                        sleepEvent_result();
                        break;
                    case "notices":
                        noticesEvent_result();
                        break;
                    case "coking":
                        cokingEvent_result();
                        break;
                    case "chair":
                        chairEvent_result();
                        break;
                    case "sofa":
                        sofaEvent_result();
                        break;
                    case "washRoom":
                        washRoomEvent_result();
                        break;
                    case "window":
                        windowEvent_result();
                        break;
                    case "washClothes":
                        washRoomEvent_result();
                        break;
                    case "None":
                        break;

                }
                this.delayTimer += 1.0f;
            }
        }
	}



    //pc
    public void pcEvent()
    {
        float timelose = Random.Range(2.0f, 6.0f) * 3600;
        log_animator.gameObject.GetComponent<Text>().text = "Playing Games for "+ (timelose / 3600.0f).ToString("#0.00") + " Hours...";
        mask_animator.SetBool("mask",true);
        log_animator.SetBool("showLog",true);
        timerHander.timeflies(timelose);
        this.currentEventName = "pc";
        this.delayTimer = 0.0f;
    }
    public void pcEvent_result()
    {
        playerCtr.happinessNumber += (5.0f + timerHander.secondsLeft/timerHander.totalTime* 15.0f);
        playerCtr.PC++;
        playerCtr.cannotMove = false;
    }
    //frontDoor
    public void frontDoorEvent()
    {
        float timelose = Random.Range(1.0f, 3.0f) * 3600;
       
        log_animator.gameObject.GetComponent<Text>().text = "eating in a restaurant for "+ (timelose / 3600.0f).ToString("#0.00") + " Hours...";
        mask_animator.SetBool("mask", true);
        log_animator.SetBool("showLog", true);
        timerHander.timeflies(timelose);
        this.currentEventName = "frontDoor";
        this.delayTimer = 0.0f;
    }
    public void frontDoorEvent_result()
    {
        playerCtr.happinessNumber += (5.0f * (playerCtr.restaurant+1));
        playerCtr.restaurant++;
        playerCtr.cannotMove = false;
    }
    public void frontDoorEvent_tooMuch()
    {
        log_animator.gameObject.GetComponent<Text>().text = "eating in a restaurant too many times...";
        //mask_animator.SetBool("mask", true);
        log_animator.SetBool("showLog", true);
    }

    //backDoor
    public void backDoorEvent()
    {
        float timelose = Random.Range(2.0f, 3.0f) * 3600;

        log_animator.gameObject.GetComponent<Text>().text = "cuting grass for " + (timelose / 3600.0f).ToString("#0.00") + " Hours...";
        mask_animator.SetBool("mask", true);
        log_animator.SetBool("showLog", true);
        timerHander.timeflies(timelose);
        this.currentEventName = "backDoor";
        this.delayTimer = 0.0f;
    }
    public void backDoorEvent_result()
    {
        playerCtr.happinessNumber += 10.0f;
        playerCtr.cutGrass++;
        playerCtr.cannotMove = false;
    }
    public void backDoorEvent_tooMuch()
    {
        log_animator.gameObject.GetComponent<Text>().text = "cuting grass too many times...";
        //mask_animator.SetBool("mask", true);
        log_animator.SetBool("showLog", true);
    }

    //2floor
    public void sleepEvent()
    {
        float timelose = Random.Range(1.0f, 10.0f) * 3600;
        log_animator.gameObject.GetComponent<Text>().text = "sleep for " + (timelose / 3600.0f).ToString("#0.00") + " Hours...";
        mask_animator.SetBool("mask", true);
        log_animator.SetBool("showLog", true);
        timerHander.timeflies(timelose);
        this.currentEventName = "2floor";
        this.delayTimer = 0.0f;
    }
    public void sleepEvent_result()
    {
        playerCtr.happinessNumber += Random.Range(-5.0f,20.0f);
        playerCtr.sleep++;
        playerCtr.cannotMove = false;
    }

    //coking
    public void cokingEvent()
    {
        float timelose = Random.Range(0.5f, 1.0f) * 3600;
        log_animator.gameObject.GetComponent<Text>().text = "coking for " + (timelose / 3600.0f).ToString("#0.00") + " Hours...";
        mask_animator.SetBool("mask", true);
        log_animator.SetBool("showLog", true);
        timerHander.timeflies(timelose);
        this.currentEventName = "coking";
        this.delayTimer = 0.0f;
    }
    public void cokingEvent_result()
    {
        playerCtr.happinessNumber += Random.Range(-5.0f, 5.0f);
        playerCtr.coking++;
        playerCtr.cannotMove = false;
    }

    //chair
    public void chairEvent()
    {
        float timelose = Random.Range(0.3f, 2.0f) * 3600;
        log_animator.gameObject.GetComponent<Text>().text = "sleeping on the chair for " + (timelose / 3600.0f).ToString("#0.00") + " Hours...";
        mask_animator.SetBool("mask", true);
        log_animator.SetBool("showLog", true);
        timerHander.timeflies(timelose);
        this.currentEventName = "chair";
        this.delayTimer = 0.0f;
    }
    public void chairEvent_result()
    {
        playerCtr.happinessNumber += Random.Range(-5.0f, 10.0f);
        playerCtr.sleepInChair++;
        playerCtr.cannotMove = false;
    }

    //sofa
    public void sofaEvent()
    {
        float timelose = Random.Range(0.6f, 3.0f) * 3600;
        log_animator.gameObject.GetComponent<Text>().text = "sleeping on the sofa for " + (timelose / 3600.0f).ToString("#0.00") + " Hours...";
        mask_animator.SetBool("mask", true);
        log_animator.SetBool("showLog", true);
        timerHander.timeflies(timelose);
        this.currentEventName = "sofa";
        this.delayTimer = 0.0f;
    }
    public void sofaEvent_result()
    {
        playerCtr.happinessNumber += Random.Range(-2.0f, 12.0f);
        playerCtr.sleepInSofa++;
        playerCtr.cannotMove = false;
    }

    //washroom
    public void washRoomEvent()
    {
        float timelose = 0.3f * 3600;
        log_animator.gameObject.GetComponent<Text>().text = "going to the washroom for " + (timelose / 3600.0f).ToString("#0.00") + " Hours...";
        mask_animator.SetBool("mask", true);
        log_animator.SetBool("showLog", true);
        timerHander.timeflies(timelose);
        this.currentEventName = "washRoom";
        this.delayTimer = 0.0f;
    }
    public void washRoomEvent_result()
    {
        playerCtr.happinessNumber += Random.Range(-6.0f, 5.0f);
        playerCtr.washRoom++;
        playerCtr.cannotMove = false;
    }

    //window
    public void windowEvent()
    {
        float timelose = 0.8f * 3600;
        log_animator.gameObject.GetComponent<Text>().text = "Looking out of the window for " + (timelose / 3600.0f).ToString("#0.00") + " Hours...";
        mask_animator.SetBool("mask", true);
        log_animator.SetBool("showLog", true);
        timerHander.timeflies(timelose);
        this.currentEventName = "window";
        this.delayTimer = 0.0f;
    }
    public void windowEvent_result()
    {
        playerCtr.happinessNumber += 2;
        playerCtr.window++;
        playerCtr.cannotMove = false;
    }

    //notices
    public void noticesEvent()
    {
        //float timelose = 0.8f * 3600;
        log_animator.gameObject.GetComponent<Text>().text = "The bill of next Month is $3000!!...";
        mask_animator.SetBool("mask", true);
        log_animator.SetBool("showLog", true);
        this.currentEventName = "notices";
        this.delayTimer = 0.0f;
    }
    public void noticesEvent_result()
    {
        if (playerCtr.checkNotices < 1)
        {
            playerCtr.happinessNumber -= 15;
        }
        playerCtr.checkNotices++;
        playerCtr.cannotMove = false;
    }

    //washClothes
    public void washClothesEvent()
    {
        float timelose =  3600.0f;

        log_animator.gameObject.GetComponent<Text>().text = "washing clothes for " + (timelose / 3600.0f).ToString("#0.00") + " Hours...";
        mask_animator.SetBool("mask", true);
        log_animator.SetBool("showLog", true);
        timerHander.timeflies(timelose);
        this.currentEventName = "washClothes";
        this.delayTimer = 0.0f;
    }
    public void washClothesEvent_result()
    {
        playerCtr.happinessNumber += 10.0f;
        playerCtr.washClothes++;
        playerCtr.cannotMove = false;
    }
    public void washClothesEvent_tooMuch()
    {
        log_animator.gameObject.GetComponent<Text>().text = "wash Clothes too many times...";
        //mask_animator.SetBool("mask", true);
        log_animator.SetBool("showLog", true);
    }

}
