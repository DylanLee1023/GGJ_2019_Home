using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmotionsController : MonoBehaviour {
    public GameManager gameManager;
    public Sprite[] emotionImgs;
    public Player_controller playerCtr;
    SpriteRenderer spriteRender;
    public float happinessNumber_last = -1;
    int tempNumber = -1;

    public Animator add_1_animator;
    public Animator add_2_animator;
    public Animator add_3_animator;

    public Animator sub_1_animator;
    public Animator sub_2_animator;
    public Animator sub_3_animator;
    // Use this for initialization
    void Start () {
        spriteRender = GetComponent<SpriteRenderer>();
        happinessNumber_last = playerCtr.happinessNumber;
    }
	
	// Update is called once per frame
	void Update () {
        if (gameManager.isGaming == false)
        {
            return;
        }
        if (playerCtr != null &&spriteRender != null)
        {
            if (playerCtr.happinessNumber > 90)
            {
                spriteRender.sprite = this.emotionImgs[18];
            }
            else
            {
                if (playerCtr.happinessNumber < 0)
                {
                    playerCtr.happinessNumber = 0;
                }
                tempNumber = (int)(playerCtr.happinessNumber / 5);
                spriteRender.sprite = this.emotionImgs[tempNumber];
            }
            if (happinessNumber_last > -1.0f)
            {
                if (happinessNumber_last > playerCtr.happinessNumber)
                {
                    emotionSub(happinessNumber_last - playerCtr.happinessNumber);
                }
                else {
                    emotionAdd(playerCtr.happinessNumber - happinessNumber_last);
                }

            }
        }


        
        
        if (Input.GetKey(KeyCode.Space))
        {
            if (this.add_1_animator != null)
            {
                this.add_1_animator.SetBool("add_1_add",true);
            }
            if (this.add_2_animator != null)
            {
                this.add_2_animator.SetBool("add_2_add", true);
            }
            if (this.add_3_animator != null)
            {
                this.add_3_animator.SetBool("add_3_add", true);
            }
        }

        if (Input.GetKey(KeyCode.R))
        {
            if (this.sub_1_animator != null)
            {
                this.sub_1_animator.SetBool("sub_1_sub", true);
            }
            if (this.sub_2_animator != null)
            {
                this.sub_2_animator.SetBool("sub_2_sub", true);
            }
            if (this.sub_3_animator != null)
            {
                this.sub_3_animator.SetBool("sub_3_sub", true);
            }
        }

    }




    void emotionAdd(float num)
    {
        if (num > 1 && num < 6)
        {
            if (this.add_1_animator != null)
            {
                this.add_1_animator.SetBool("add_1_add", true);
            }
            this.happinessNumber_last = this.playerCtr.happinessNumber;
        }
        else if (num >= 6 && num < 12)
        {
            if (this.add_1_animator != null)
            {
                this.add_1_animator.SetBool("add_1_add", true);
            }
            if (this.add_2_animator != null)
            {
                this.add_2_animator.SetBool("add_2_add", true);
            }
            this.happinessNumber_last = this.playerCtr.happinessNumber;
        }
        else
        {
            if (this.add_1_animator != null)
            {
                this.add_1_animator.SetBool("add_1_add", true);
            }
            if (this.add_2_animator != null)
            {
                this.add_2_animator.SetBool("add_2_add", true);
            }
            if (this.add_3_animator != null)
            {
                this.add_3_animator.SetBool("add_3_add", true);
            }
            this.happinessNumber_last = this.playerCtr.happinessNumber;

        }
    }

    void emotionSub(float num)
    {
        if (num > 1 && num < 10)
        {
            if (this.sub_1_animator != null)
            {
                this.sub_1_animator.SetBool("sub_1_sub", true);
            }
            this.happinessNumber_last = this.playerCtr.happinessNumber;
        }
    }

}
