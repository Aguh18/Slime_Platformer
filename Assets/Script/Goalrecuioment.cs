using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goalrecuioment : MonoBehaviour
{
    public static Goalrecuioment singleton;
    public  int maxgoalrequipment, goalcollectedrequipment;
    public bool SyaratTerpenuhi;

    private void Awake() {
        singleton = this;
    }
    public void Syaratgoal(){
        goalcollectedrequipment++;
        if(goalcollectedrequipment >=maxgoalrequipment){
            goalcollectedrequipment = maxgoalrequipment;
            SyaratTerpenuhi = true;
        }
    }
    public void goal(){
        if(SyaratTerpenuhi == true){
            print("selamat kamu menang");
        }
    }


}
