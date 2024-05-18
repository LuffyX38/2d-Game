using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrialPlayer : MonoBehaviour
{
    [SerializeField] private float moveForce = 10f;
    private float movementX;
    private Rigidbody2D myBody;
    private Animator anim;
    [SerializeField] private LayerMask layerMask;
    private SpriteRenderer sr;
    private BoxCollider2D boxCollider2d;
    private Player_Base playerBase;

    void Start()
    { 
        playerBase = gameObject.GetComponent<Player_Base>();
        myBody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
        
    }

    void Update()
    {
           PlayerRun();
            AnimatePlayer();

            if(IsGrounded() && Input.GetKeyDown(KeyCode.Space)){
                float jumpVelocity = 100f;
                myBody.velocity = Vector2.up * jumpVelocity;
            }
    }

    private bool IsGrounded(){
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.centre, boxCollider2d.bounds.size, 0f, Vector2.down* .1f);
        Debug.Log(raycastHit2d.collider);
        return raycastHit2d.collider != null;
    }


     private void PlayerRun(){
        movementX =Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX,0f,0f) * Time.deltaTime * moveForce;
        Time.timeScale = 1f;
        }

        void AnimatePlayer(){
       if(movementX > 0){
           anim.SetBool("isRunning",true);
           sr.flipX = false;
       }else if(movementX < 0){
           anim.SetBool("isRunning",true);
           sr.flipX = true;
       }else{
           anim.SetBool("isRunning",false);
       }
        }
       

}
