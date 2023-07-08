using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    private void Start() {
        
    }

    private void Update() {
        
    }
    
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Enemy")) {
            Fish fish = other.gameObject.GetComponent<Fish>();
            fish.health -= 1;
            if (fish.health <= 1) {
                fish.GetComponent<Rigidbody2D>().mass = 0.1f;
                fish.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            }
            Destroy(gameObject);
        }
    }
}
