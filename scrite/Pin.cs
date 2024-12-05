using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    [SerializeField] public float speed = 20f;
    [SerializeField] public Rigidbody2D rb;


    [SerializeField] public int damage = 20;

    // Start is called before the first frame update
    private void Start()
    {
        rb.velocity = transform.up * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

            // Destroy this GameObject if it collides with a BoxCollider2D
            Destroy(this.gameObject);




    }






}

