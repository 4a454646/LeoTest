using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
    [Header("Player Movement")]
    [SerializeField] private float maxVel = 0.3f;
    [SerializeField] private float acceleration = 0.05f;
    [SerializeField] private float deceleration = 0.5f;
    [SerializeField] private float currentSpeed = 0.0f;
    
    private void Start() {
        
    }

    
    private void Update() {
        
    }

    private void FixedUpdate() { 
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal == 0) {
            currentSpeed = currentSpeed * deceleration;
            if (currentSpeed < 0.01f && currentSpeed > -0.01f) {
                currentSpeed = 0;
            }
        }
        else {
            currentSpeed = currentSpeed + horizontal * acceleration;
            currentSpeed = Mathf.Clamp(currentSpeed, -maxVel, maxVel);
        }
        transform.position = new Vector3(
            transform.position.x + currentSpeed, 
            transform.position.y,
            0
        );
    }    
}
