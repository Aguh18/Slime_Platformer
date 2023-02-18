using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float movementspeed;
    public bool IsfacingRight;

    public Transform hpbar;
    //Ground checker and wall checker
    public Transform enemypos, wallpos;
    public LayerMask Whatisground;
    public float Enemyradius;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * movementspeed *Time.deltaTime);

        if(!Isgrounded()){
            if(IsfacingRight){
                hpbar.localEulerAngles = Vector2.zero;
                transform.eulerAngles = Vector2.up * 180;
                IsfacingRight = false;}
            else
            {
                hpbar.localEulerAngles = Vector2.up * 180;
                transform.eulerAngles = Vector2.zero;
                IsfacingRight = true;
            }

        }
    }
    bool Isgrounded(){
        return Physics2D.OverlapCircle(enemypos.position,Enemyradius, Whatisground);
    }
    bool Iswalled(){
        return Physics2D.OverlapCircle(enemypos.position,Enemyradius, Whatisground);}
    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(enemypos.position,Enemyradius);
        Gizmos.DrawWireSphere(wallpos.position,Enemyradius);
    }
}
