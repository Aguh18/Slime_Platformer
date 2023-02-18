using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float bulletspeed, bulletdamage, timedestroy;
    private void Awake() {
        Destroy(gameObject, timedestroy);
    }
    void Update()
    {
        transform.Translate(Vector3.right*bulletspeed*Time.deltaTime);
    }
   private void OnTriggerEnter2D(Collider2D collision) {
    if(collision.CompareTag("enemy")){
        collision.transform.parent.transform.parent.GetComponent<EnemyHealth>().Takedamage(bulletdamage);
        Destroy(gameObject);
        print("kena damage");
    }
    else if (collision.CompareTag("environtment")){
        Destroy(gameObject);
        print("kena tembok");
    }
   }
}
