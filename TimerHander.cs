using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TimerHander : MonoBehaviour {
    public long  totalTime = 9990;
    public float secondsLeft ;
    public float secondsLeft_timeflies = -1.0f;
    public float timefliesTime = -1.0f;
    public Text text;
    public Player_controller playerCtr;
    public GameManager gameManager;
    // Use this for initialization
    void Start () {
        secondsLeft = totalTime;
        secondsLeft_timeflies = secondsLeft + 1.0f;
    }
	
	// Update is called once per frame
	void Update () {
        if (gameManager.isGaming == false)
        {
            return;
        }
        if (secondsLeft < 0)
        {
            gameManager.win();
        }
        text.text = (int)(secondsLeft/86400)+"D "+ (int)((secondsLeft % 86400))/ 3600 + "H " + (int)(((secondsLeft % 86400) % 3600)/60) + "M " + (int)(((secondsLeft % 86400) % 3600) % 60) + "S ";
        //Debug.Log(text.text);
        if (secondsLeft > secondsLeft_timeflies)
        {
            secondsLeft -= (timefliesTime/8.0f* Time.deltaTime + Time.deltaTime * 800.0f);
            if (secondsLeft_timeflies > secondsLeft)
            {
                //secondsLeft_timeflies = -1.0f;
                timefliesTime = -1.0f;
            }
        }
        else {
            secondsLeft -= Time.deltaTime * 800.0f;
            if (playerCtr.happinessNumber > playerCtr.happinessNumberSubPerSecond * Time.deltaTime * 800)
            {
                playerCtr.happinessNumber -= playerCtr.happinessNumberSubPerSecond * Time.deltaTime * 800;
            }
            else
            {
                gameManager.GameOver();
            }
        }
        

    }

    public void timeflies(float seconds)
    {
        Debug.Log(seconds.ToString());
        secondsLeft_timeflies = secondsLeft -seconds + 1.0f;
        timefliesTime = seconds;

    }


}
