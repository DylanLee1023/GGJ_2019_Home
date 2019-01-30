using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour {
    public GameManager gameManager;
    public Transform scalePoint;
    public HomeEventHandler homeEventHandler;
    public Animator player_animator;
    public Animator popInfo_animator;
    public float m_speed;
    public int state = 0;
    public float disBetweenPlayer_scalePoint = 14.6f;
    Vector3 scaleNewVec3;

    public bool cannotMove = false;

    public float bankBanlance = 0;
    [Range(0, 100)]
    public float happinessNumber = 100;
    public float happinessNumberSubPerSecond = 0.01f;

    string stateAreaName = "None";

    public int PC = 0;
    public int restaurant = 0;
    public int cutGrass = 0;
    public int sleep = 0;
    public int checkNotices = 0;
    public int coking = 0;
    public int playGames = 0;
    public int sleepInChair = 0;
    public int sleepInSofa = 0;
    public int washRoom = 0;
    public int window = 0;
    public int washClothes = 0;
    public int checkWallet = 0;
    public int checkPhone = 0;

    // Use this for initialization
    void Start () {
        scaleNewVec3 = new Vector3(0.1f,0.1f,1.0f);
        

    }
	
	// Update is called once per frame
	void Update () {
        if (gameManager.isGaming == false)
        {
            return;
        }
        //Debug.Log(Vector3.Distance(this.transform.position,this.scalePoint.transform.position).ToString());
        float newScaleSize = 0.25f - Vector3.Distance(this.transform.position, this.scalePoint.transform.position) / disBetweenPlayer_scalePoint * 0.13f;
        scaleNewVec3.x = scaleNewVec3.y =newScaleSize;
        this.transform.localScale = scaleNewVec3;
        //Debug.Log(newScaleSize.ToString());

        MoveControlByMove();
        interacting();

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        this.stateAreaName = other.name;
        popInfo_animator.SetBool("In",true);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        popInfo_animator.SetBool("In", false);
        popInfo_animator.SetBool("Out", true);
        this.stateAreaName = "None";
    }

    void MoveControlByMove()
    {
        float horizontal = Input.GetAxis("Horizontal"); //A D 左右
        float vertical = Input.GetAxis("Vertical"); //W S 上 下
        if (horizontal == 0 && vertical == 0)
        {
            this.state = 0;
            this.player_animator.SetBool("IsWalking", false);
        }
        else
        {
            this.state = 1;
            this.player_animator.SetBool("IsWalking", true);
        }
        if (cannotMove)
        {
            return;
        }

        this.transform.Translate(Vector3.up * vertical * m_speed * Time.deltaTime);
        this.transform.Translate(Vector3.right * horizontal * m_speed * Time.deltaTime);

    }

    void interacting()
    {
        if (cannotMove)
        {
            return;
        }
        if (Input.GetKey(KeyCode.E))
        {
            switch (this.stateAreaName)
            {
                case "PC":
                    this.homeEventHandler.pcEvent();
                    cannotMove = true;
                    break;
                case "frontDoor":
                    if (this.restaurant < 3)
                    {
                        this.homeEventHandler.frontDoorEvent();
                        cannotMove = true;
                    }
                    else
                    {
                        this.homeEventHandler.frontDoorEvent_tooMuch();
                    }
                   
                    break;
                case "backDoor":
                    if (this.cutGrass < 1)
                    {
                        this.homeEventHandler.backDoorEvent();
                        cannotMove = true;
                    }
                    else
                    {
                        this.homeEventHandler.backDoorEvent_tooMuch();
                    }
                    break;
                case "2floor":
                    this.homeEventHandler.sleepEvent();
                    cannotMove = true;
                    break;
                case "Notices":
                    this.homeEventHandler.noticesEvent();
                    cannotMove = true;
                    break;
                case "Coking":
                    this.homeEventHandler.cokingEvent();
                    cannotMove = true;
                    break;
                case "Chair":
                    this.homeEventHandler.chairEvent();
                    cannotMove = true;
                    break;
                case "Sofa":
                    this.homeEventHandler.sofaEvent();
                    cannotMove = true;
                    break;
                case "WashRoom":
                    this.homeEventHandler.washRoomEvent();
                    cannotMove = true;
                    break;
                case "Window":
                    this.homeEventHandler.windowEvent();
                    cannotMove = true;
                    break;
                case "WashClothes":
                    if (this.washClothes < 1)
                    {
                        this.homeEventHandler.washClothesEvent();
                        cannotMove = true;
                    }
                    else
                    {
                        this.homeEventHandler.washClothesEvent_tooMuch();
                    }

                    break;
                case "None":
                    break;
            }
        }
    }

    void addLog(string eventName)
    {



    }


}
