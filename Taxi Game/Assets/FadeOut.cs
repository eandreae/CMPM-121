using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{

    public Text scoreData;
    private int score = 0;

    private Text scoreTag;
    private float r;
    private float g;
    private float b;
    private float a;

    void Start ()
    {
        scoreTag = this.GetComponent<Text>();
        Color scoreTagColor = scoreTag.color;
        r = scoreTag.color.r;
        g = scoreTag.color.g;
        b = scoreTag.color.b;
        a = scoreTag.color.a;

        updateScore();

    }

    // Update is called once per frame
    void Update()
    {
        a -= Time.deltaTime/5;

        Color newColor = new Color(r, g, b, a);
        
        scoreTag.color = newColor;

        if ( a <= 0 )
        {
            scoreTag.text = "";
        }
    }

    void updateScore () 
    {
        scoreData.text = score.ToString();
    }

    public void ResetTime(string s) 
    {
        if (s == "pickUp")
        {
            scoreTag.text += "+5 Picked Up Passenger\n";
            score += 5;
            updateScore();
        }
        if (s == "dropOff")
        {
            scoreTag.text += "+10 Dropped Off Passenger\n";
            score += 10;
            updateScore();
        }
        if (s == "inZone")
        {
            scoreTag.text += "+10 Dropped Off In Right Area\n";
            score += 10;
            updateScore();
        }
        if (s == "ranRed")
        {
            scoreTag.text += "-1 Ran A Red Light\n";
            score -= 1;
            updateScore();
        }
        if (s == "ranOver")
        {
            scoreTag.text += "-20 Ran Over Passenger\n";
            score -= 20;
            updateScore();
        }

        a = 1;

    }
}
