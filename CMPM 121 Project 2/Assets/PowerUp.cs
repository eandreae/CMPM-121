using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    bool wasPickedUp = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var transform = this.GetComponent<Transform>();
        transform.localRotation *= Quaternion.Euler(0.0f, 200.0f * Time.deltaTime, 0.0f);

        if ( this.wasPickedUp ){
            transform.localScale *= 0.8f;
        }

        // this.GetComponent<Camera>().depth = ...;
    }

    void OnTriggerEnter(Collider collider) {
        if ( collider.gameObject.CompareTag("Player") && this.tag == "PowerUp" ){
            // Make the object dissapear
            Debug.Log("powerup collision");
            Object.Destroy(this.gameObject, 0.1f);
            // Make the pickup be true
            wasPickedUp = true;
        }
    }
}
