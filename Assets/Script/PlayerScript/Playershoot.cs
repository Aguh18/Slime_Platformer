using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playershoot : MonoBehaviour
{
    public Transform bulletpos;
    public GameObject bullet;

    // Update is called once per frame
    void Update()
    {
        shoot();
    }

    void shoot(){
        if(Input.GetKeyDown(KeyCode.Z)){
        Instantiate(bullet,bulletpos.position,transform.rotation);}
    }
}
