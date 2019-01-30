using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour {

    // Use this for initialization
    void Start() {
       
    }

    // Update is called once per frame
    void Update() {
        


    }



    public void button_play_click()
    {
       
       SceneManager.LoadScene("Game");
    }

    public void button_exit_click()
    {
        Application.Quit();
    }
}
