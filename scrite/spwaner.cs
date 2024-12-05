using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spwaner : MonoBehaviour
{
    const int NUM = 5;
    [SerializeField] GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
 
    }
    void Spawn()
    {
        int xMin = -8;
        int xMax = 8;
        int yMin = 3;
        int yMax = 5;

        for (int i = 0; i <NUM; i++)
        {

            Vector2 position = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
            Instantiate(ball, position, Quaternion.identity);
        }
    }
}
