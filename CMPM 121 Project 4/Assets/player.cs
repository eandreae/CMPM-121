using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{

    public float speed      = 10.0f;
    public float rotateSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // From the Unity documentation on simplemove.
        CharacterController controller = GetComponent<CharacterController>();

        transform.Rotate(
            0.0f, 
            Input.GetAxis("Horizontal") * this.rotateSpeed,
            0.0f
        );

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = this.speed * Input.GetAxis("Vertical");
        controller.SimpleMove(forward * curSpeed);

        
    }
}
