using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{

    public float speed = 10.0f;

    public float score = 0;

    public Text scoreData;
    public Text multData;

    public float scoreMult = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void updateScore(){
        this.scoreData.text = this.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // Manual movement
        // var transform = this.GetComponent<Transform>();
        // var position = transform.position;
        // position.x += this.speed * Input.GetAxis("Horizontal") * Time.deltaTime;
        // position.z += this.speed * Input.GetAxis("Vertical") * Time.deltaTime;
        // Debug.Log(Input.GetAxis("Horizontal"));
        // transform.position = position;

        // Character Controller movement.
        this.scoreMult = 1 + score / 10;
        this.multData.text = this.scoreMult.ToString();

        var characterController = this.GetComponent<CharacterController>();
        characterController.SimpleMove(new Vector3(
            this.speed * Input.GetAxis("Horizontal") * scoreMult,
            0.0f,
            this.speed * Input.GetAxis("Vertical") * scoreMult
        ));
        
    }

    void OnTriggerEnter(Collider collider) {
        if ( collider.gameObject.CompareTag("PowerUp") ){
            // Make the object dissapear
            Debug.Log("player collision");
            // Add the score on the UI
            this.score += 1;
            this.scoreData.text = this.score.ToString();
            // Set the tag to something else.
            collider.gameObject.tag = "Finish";
        }
        
    }
}
