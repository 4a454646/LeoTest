using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // delete anyting that collides with this object
    private void OnCollisionEnter2D(Collision2D other) {
        Destroy(other.gameObject);
    }
}
