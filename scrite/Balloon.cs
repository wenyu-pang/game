using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Balloon : MonoBehaviour
{
    [SerializeField] AudioSource audio;
    [SerializeField] public float maxSize = 2.0f; // Maximum allowed size before disappearing
    [SerializeField] public float growthRate = 0.1f; // Rate of balloon growth
    [SerializeField] public float baseScore = 50f; // Base score for smallest balloons
    [SerializeField] private information s; // Starting score
    [SerializeField]private Level L;//level
    [SerializeField] private int ball=5;//how many ball
    [SerializeField] private CircleCollider2D circleCollider;
    void Start()
    {
        // Get the CircleCollider2D component
        circleCollider = GetComponent<CircleCollider2D>();
        audio = GetComponent<AudioSource>();
        // Invoke the GrowBalloon function every 1 second
        InvokeRepeating("GrowBalloon", 1.5f, 1.5f);
        s = FindObjectOfType<information>();
        L = FindObjectOfType<Level>();

    }

    void GrowBalloon()
    {
        // Increase the balloon's scale
        transform.localScale += new Vector3(growthRate, growthRate, 0);

        // Adjust the CircleCollider2D radius to match the balloon's exact size
        if (circleCollider != null)
        {
            circleCollider.radius = transform.localScale.x / 2; // Keep radius in sync with balloon scale
        }

        // Check if the balloon is too big and needs to disappear
        if (transform.localScale.x >= maxSize || transform.localScale.y >= maxSize)
        {
            L.s=true;
            Destroy(this.gameObject); // Destroy balloon with no points


        }

    }
    public void PopBalloon()
    {
        // Calculate score based on current balloon size
        float sizeFactor = maxSize / transform.localScale.x; // Smaller balloons have a higher sizeFactor
        int points = Mathf.FloorToInt(baseScore * sizeFactor);

        // Add points to the total score

        s.scored += points;
        PersistentData.Instance.AddScore(points);
        L.ball--;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision detected with: " + collision.name);
        if (collision.CompareTag ("pin"))
        {
            Debug.Log("Pin detected, popping balloon.");

            PopBalloon();
            // Destroy the balloon after it's popped
            AudioSource.PlayClipAtPoint(audio.clip, transform.position);
            Destroy(this.gameObject);
            
        }

        //  else if (collision.tag == "bullet")
        // {
        //  Destroy(this.gameObject);
        //}
    }

}