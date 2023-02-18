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
    
    private void Move(){
        rightleft = Input.GetAxisRaw("Horizontal");

        if (rightleft != 0){
            anim.SetTrigger(walkcondition);
        }
        else{
            anim.SetTrigger(Idle_Condition);
        }
        rb.velocity = new Vector2(rightleft * Movespeed, rb.velocity.y);
        if (rightleft > 0 && !Isfacingright){
            transform.eulerAngles = Vector2.zero;
            Isfacingright = true;
        }
        else if( rightleft < 0 && Isfacingright) {
            transform.eulerAngles = Vector2.up * 180;
            Isfacingright = false;
        }
    }

    void Jump(){
        if ( Input.GetKeyDown(KeyCode.Space) && Isgrounded() || Input.GetKeyDown(KeyCode.W) &&  Isgrounded()){
            rb.velocity = Vector2.up * jumpforce;
        }
        if (!Isgrounded() && !Isjumping){
            anim.SetTrigger(jumpcondition);
            Isjumping = true;
        }
        else if(Isgrounded()&& Isjumping){
            anim.SetTrigger(landcondition);
            Isjumping = false;
        }
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
