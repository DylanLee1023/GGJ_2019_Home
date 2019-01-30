using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Add_Sub_animation_CallBack : MonoBehaviour {



    public void CallBack(string name)
    {
        this.GetComponent<Animator>().SetBool(name,false);
    }

}
