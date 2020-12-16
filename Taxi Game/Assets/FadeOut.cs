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
        if (s == "taxi")
        {
            scoreTag.text += "+20 Clicked Taxi\n";
            score += 20;
            updateScore();
        }
        if (s == "pickUp")
        {

        }
        if (s == "dropOff")
        {

        }
        if (s == "inZone")
        {

        }
        if (s == "ranRed")
        {
            
        }

        a = 1;

    }
}
