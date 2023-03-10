using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //reference
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;

    //Animation
    string Idle_Condition = "idle", walkcondition = "walk",jumpcondition = "jump",landcondition = "land";

    // move
    public float jumpforce,Movespeed,rightleft;
    public bool Isjumping;

    //Isgrounded
    public Transform Ground;
    public float radius;
    public  LayerMask whatisground;

    

    //kiri kanan
    public bool Isfacingright;
    // Start is called before the first frame update

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    private void FixedUpdate() {
        Move();
    }
    
    
    bool Isgrounded(){
        return Physics2D.OverlapCircle(Ground.position,radius,whatisground);
    }
    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(Ground.position,radius);
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("hollywater")){
            Goalrecuioment.singleton.Syaratgoal();
            Destroy(collision.gameObject);
        }
        else if(collision.CompareTag("goal")){
            Goalrecuioment.singleton.goal();
        }
    }
    
}
