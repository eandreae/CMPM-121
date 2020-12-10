using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Waypoint : MonoBehaviour
{
    public TextMeshProUGUI scoreData;
    public TextMeshProUGUI timerData;
    private float MIN_Z = -245.0f;
    private float MAX_Z = 105.0f;
    private float score;
    // Start is called before the first frame update
    void Start()
    {
        float startX = generateX();
        float startY = generateY();
        float startZ = generateZ();

        moveWaypoint(startX, startY, startZ);

        score = 0.0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        string gameOver = "Game Over!";
        if ( timerData.text == gameOver ){
            Debug.Log("Time's up!");
            Object.Destroy(this.gameObject, 0.0f);
        }
    }

    void OnTriggerEnter(Collider collider) {
        if ( collider.gameObject.CompareTag("Player") ){
            Debug.Log("Collided with the player!");

            float X = generateX();
            float Y = generateY();
            float Z = generateZ();

            moveWaypoint(X, Y, Z);

            updateScore();
        }
    }

    void updateScore() {
        this.score += 1.0f;
        scoreData.text = score.ToString();
    }

    float generateX () {
        // Generates an X value within the range.
        // For the protoype, there are only 4 possibilities.
        // X values of -65, -55, 55, 65

        float scenario = Random.Range(0.0f, 4.0f);
        // Scenario 1 = -65.0f. 
        if ( scenario >= 0.0f && scenario <= 1.0f ){return -65.0f;}
        if ( scenario > 1.0f && scenario <= 2.0f ){return -55.0f;}
        if ( scenario > 2.0f && scenario <= 3.0f ){return 55.0f;}
        else {return 65.0f;}    

    }

    float generateY () {
        // Generates a Y value within the range.
        // Defaults to 3.
        return 3.0f;
    }

    float generateZ () {
        // Generates a Z value within the range.
        float position = Random.Range(MIN_Z, MAX_Z);
        return position;
    }

    void moveWaypoint(float x, float y, float z) {
        var transform = this.GetComponent<Transform>();
        var position = transform.position;
        position.x = x;
        position.y = y;
        position.z = z;
        transform.position = position;
    }
}
