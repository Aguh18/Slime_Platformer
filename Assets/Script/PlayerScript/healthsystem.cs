using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class healthsystem : MonoBehaviour
{
    public int health;
    public GameObject[] HealthUI;
void takedamage(){
    health--;
    if (health <= 0){
        health = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    HealthUI[health].SetActive(false);
}
private void OnTriggerEnter2D(Collider2D collision) {
    if (collision.CompareTag("enemy")){
        takedamage();
    }
    else if(collision.CompareTag("Spike")){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
}
}
