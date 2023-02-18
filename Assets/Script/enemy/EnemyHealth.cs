using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float Enemyhealth;
    float maxhealth;
    public Image hpbar;
    private void Awake() {
        maxhealth = Enemyhealth;
    }

    public void Takedamage(float damage){
        Enemyhealth = Enemyhealth - damage;
         hpbar.fillAmount =  Enemyhealth/ maxhealth;

        if(Enemyhealth <= 0){
            Destroy(gameObject);
        }
       

    }
}
