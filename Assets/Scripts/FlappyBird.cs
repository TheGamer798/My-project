using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBird : MonoBehaviour
{
    public GameObject Ship;
    public float Gravity = 30;
    public float Jump = 10;

    private float VerticalSpeed;

    void Start()
    {
        
    }

    
    void Update()
    {
        VerticalSpeed += -Gravity * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            VerticalSpeed = 0;
            VerticalSpeed += Jump;
        }

        Ship.transform.position += Vector3.up * VerticalSpeed * Time.deltaTime;
    }
}
