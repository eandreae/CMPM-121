using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaypointHUD : MonoBehaviour
{

    public Image img;
    public Text distance;

    public Text WaypointData;
    public GameObject SpawnPoints;
    public GameObject Destinations;
    public GameObject pickedUp;
    public GameObject jobStarted;

    private GameObject temp;
    private Transform target;
    private string random;

    // Update is called once per frame
    void Update()
    {
        if( jobStarted.activeSelf == true )
        {
            img.enabled = true;
            distance.enabled = true;

            random = WaypointData.text;
            if( pickedUp.activeSelf == false )
            {
                temp = SpawnPoints.transform.Find(random).gameObject;
            }
            else 
            {
                temp = Destinations.transform.Find(random).gameObject;
            }


            target = temp.GetComponent<Transform>();

            float minX = img.GetPixelAdjustedRect().width / 2;
            float maxX = Screen.width - minX;

            float minY = img.GetPixelAdjustedRect().height / 2;
            float maxY = Screen.height - minY;   

            Vector2 pos = Camera.main.WorldToScreenPoint(target.position);

            if(Vector3.Dot((target.position - transform.position), transform.forward) < 0)
            {
                // Target is behind the player
                if(pos.x < Screen.width / 2)
                {
                    pos.x = maxX;
                }
                else{
                    pos.x = minX;
                }
            }

            pos.x = Mathf.Clamp(pos.x, minX, maxX);
            pos.y = Mathf.Clamp(pos.y, minY, maxY);

            img.transform.position = pos;
            distance.text = ((int)Vector3.Distance(target.position, transform.position)).ToString() + "m";
        }
        else
        {
            img.enabled = false;
            distance.enabled = false;
        }
    }
}
