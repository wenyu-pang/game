using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autormove1 : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5.0f; // Speed of the object's movement
    [SerializeField] public float moveLimit = 5.0f; // The limit to move between -moveLimit and +moveLimit on the x-axis

    [SerializeField] private int direction = 1; // Current direction of movement (1 for right, -1 for left)

    void Update()
    {
        // Move the object in the current direction
        transform.position += new Vector3(moveSpeed * direction * Time.deltaTime, 0, 0);

        // Check if the object has reached the limit on either side
        if (transform.position.x >= moveLimit)
        {
            direction = -1; // Move left
        }
        else if (transform.position.x <= -moveLimit)
        {
            direction = 1; // Move right
        }
    }
}
