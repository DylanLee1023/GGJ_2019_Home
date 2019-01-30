using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {
    
    public bool isGaming = false;
    public SpriteRenderer sr;
    public Text text;
    public Text points;
    public Button button_backToMenu;
    public Player_controller playerCtr;
    public TimerHander timehandler;
    
    // Use this for initialization
    void Start () {
        this.gameStart();

    }
	
	// Update is called once per frame
	void Update () {
        if (isGaming == false && playerCtr.happinessNumber > 0 && timehandler.secondsLeft > 1)
        {
            if (this.sr.gameObject.activeSelf && this.text.gameObject.activeSelf && this.points.gameObject.activeSelf)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    this.sr.gameObject.SetActive(false);
                    text.gameObject.SetActive(false);
                    points.gameObject.SetActive(false);
                    isGaming = true;
                }
            }
        }
	}

    public void gameStart()
    {
        this.sr.gameObject.SetActive(true);
        text.fontSize = 70;
        points.fontSize = 43;
        text.text = "Honey, I have to go on a business trip for 3 days. please try your best to be happy at home. There are many things you can do at home. Love U~";
        points.text = "Press 'E' to start the game \n W- up S- down A- left D- right";
        points.text = points.text.Replace("\\n", "\n");
        text.gameObject.SetActive(true);
        points.gameObject.SetActive(true);
    }

    public void GameOver()
    {
        Debug.Log("gameover");
        isGaming = false;
        sr.gameObject.SetActive(true);
        text.text = "Unfortunately, you crashed before your girlfriend came back!";
        points.text = "You insisted for: " + ((timehandler.totalTime - timehandler.secondsLeft) / 3600.0f).ToString("#0.000") + " Hours...";
        text.gameObject.SetActive(true);
        points.gameObject.SetActive(true);
        button_backToMenu.gameObject.SetActive(true);
    }

    public void win()
    {
        Debug.Log("win");
        isGaming = false;
        sr.gameObject.SetActive(true);
        text.text = "Congratulations, you didn’t crash before your girlfriend came back!";
        points.text = "your points is: " + playerCtr.happinessNumber;
        text.gameObject.SetActive(true);
        points.gameObject.SetActive(true);
        button_backToMenu.gameObject.SetActive(true);
    }

    public void button_back()
    {
        SceneManager.LoadScene("Menu");
    }


}
