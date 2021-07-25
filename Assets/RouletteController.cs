using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteController : MonoBehaviour
{

    float rotSpeed = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Set rotate speed if click
        if (Input.GetMouseButtonDown(0))
        {
            this.rotSpeed = 1000;
        }

        // Rotate Roulette as much as rotate speed
        transform.Rotate(0, 0, this.rotSpeed);

        // Decelerate roulette speed
        this.rotSpeed *= 0.96f;
    }
}
