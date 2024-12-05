using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerattack : MonoBehaviour
{
    [SerializeField] public float shootCooldown = 0.2f;
    [SerializeField] private float cooldownTimer = 0.0f;
    //shotting postation
    [SerializeField] public Transform firePoint;
    //bullet
    [SerializeField] public GameObject b;
    // Update is called once per frame
    void Update()
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.J) && cooldownTimer <= 0)
        {
            shoot();
        }
        void shoot()
        {
            Instantiate(b, firePoint.position, firePoint.rotation);
            cooldownTimer = shootCooldown;
        }
    }


}

