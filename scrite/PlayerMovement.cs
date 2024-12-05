using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour

{
    [SerializeField] private float speed=5;
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private Animator anim;
    [SerializeField] private bool ground =true;
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim= GetComponent<Animator>();
    }


    void Update()
    {
        float hz = Input.GetAxis("Horizontal");
        
        body.velocity = new Vector2(hz * speed, body.velocity.y);
        if (hz > 0.01f)
            transform.localScale = new Vector3(1, transform.localScale.y, 1);
        else if (hz < -0.01f)
            transform.localScale = new Vector3(-1, transform.localScale.y, 1);
        /*if (Input.GetKey(KeyCode.Space) && ground )
        {
            Jump();


        }*/
        anim.SetBool("run", hz != 0);
    }
    //set animator parmeters
        
    /*void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        ground = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "block")
        {
            ground = true;
        }
    }*/
}
