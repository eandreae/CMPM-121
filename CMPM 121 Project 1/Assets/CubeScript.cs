using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeScript : MonoBehaviour
{

    public float speed = 0.05f;
    public float rotation_Speed = 1f;
    public float scale_speed = 0.005f;
    public float sign = 1f;
    public float multiplier = 1f;
    public float color_sign = -1f;
    public float color_iterator = 0.005f;
    public float zoomies = 0f;

    public Slider slider;

    public Text zoomies_level;
    public Text multiplier_level;

    

    Transform transform;

    // Start is called before the first frame update
    void Start()
    {
        this.transform = this.GetComponent<Transform>();

    }
 
    public void GoFaster() {
        Debug.Log("GoFaster was called!!!");
        // Increase speed, rotation, and scale.
        this.speed += 0.1f;
        this.rotation_Speed += 1f;
        this.scale_speed += 0.005f;
        // Add the zoomies
        this.zoomies += 1f;
        this.zoomies_level.text = this.zoomies.ToString();
        // Increase the color_iterator zoomies
        this.color_iterator += 0.005f;

    }

    public void ChangeMultiplier() {
        Debug.Log("ChangeMultiplayer was called!!!");
        Debug.Log(this.slider.value);
        
        this.multiplier = this.slider.value;
        this.multiplier_level.text = this.multiplier.ToString();
        //this.multiplier = new_multiplier;

    }

    public void FlipSigns() {
        Debug.Log("FlipSigns was called!!!");
        // Flip the main sign.
        this.sign *= -1f;
    }

    public void resetLeft() {
        // For when it flies off the left side of the screen.
        var new_position = this.transform.position;
        new_position.x = 10f;
        this.transform.position = new_position;
    }

    public void resetRight() {
        // For when it flies off the right side of the screen.
        var new_position = this.transform.position;
        new_position.x = -10f;
        this.transform.position = new_position;
    }

    public void updateZoomies() {
        this.zoomies_level.text = this.zoomies.ToString();
    }

    public void updateMultiplier() {
        this.multiplier_level.text = this.multiplier.ToString();
        this.slider.value = this.multiplier;
    }

    // Update is called once per frame
    void Update()
    {
        // Change the position of the cube
        var new_position = this.transform.position;
        new_position.x += this.speed * Time.deltaTime * this.sign * this.multiplier;
        this.transform.position = new_position;
        // Change the rotation of the cube
        var new_rotation = this.transform.localRotation;
        new_rotation = Quaternion.Euler(rotation_Speed * Time.deltaTime * this.sign * this.multiplier, 0.0f, 0.0f) * new_rotation;
        this.transform.localRotation = new_rotation;
        // Change the scale of the cube
        var new_scale = this.transform.localScale;
        // Y value
        new_scale.y += this.scale_speed * Time.deltaTime * this.sign * this.multiplier / 7;
        // X value
        new_scale.x += this.scale_speed * Time.deltaTime * this.sign * this.multiplier / 7;
        // Z value
        new_scale.z += this.scale_speed * Time.deltaTime * this.sign * this.multiplier / 7;
        // Apply the new scale.
        this.transform.localScale = new_scale;

        //gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

        var mesh_renderer = this.GetComponent<MeshRenderer>();
        //Debug.Log(mesh_renderer);
        var material = mesh_renderer.materials[0];
        var color = material.color;
        //Debug.Log(color);
        color.r += color_iterator * this.color_sign * this.multiplier;
        color.g += color_iterator * this.color_sign * this.multiplier;
        color.b += color_iterator * this.color_sign * this.multiplier;

        if ( color.r <= 0.0f ){
            this.color_sign *= -1.0f;
        } else if ( color.r >= 1.0f ){
            this.color_sign *= -1.0f;
        }

        material.color = color;

        // If the chicken flies off the edge, reset it to the other edge.
        if ( this.transform.position.x > 11f ){
            // If it flies off the right of the screen
            resetRight();
        } else if ( this.transform.position.x < -11f ){
            // If it fies off the left side of the screen
            resetLeft();
        }
        
    }

    public void Save() {
        Debug.Log("Game Saved!");

        /* Default values
        public float speed = 0.05f;
        public float rotation_Speed = 1f;
        public float scale_speed = 0.005f;
        public float zoomies = 0f;
        public float sign = 1f;
        public float color_sign = -1f;
        public float multiplier = 1f;
        public float color_iterator = 0.005f;
        
        */

        PlayerPrefs.SetFloat("chicken-speed", this.speed);
        PlayerPrefs.SetFloat("chicken-rotation-speed", this.rotation_Speed);
        PlayerPrefs.SetFloat("chicken-scale-speed", this.scale_speed);
        PlayerPrefs.SetFloat("chicken-zoomies", this.zoomies);
        PlayerPrefs.SetFloat("multiplier-value", this.multiplier);
    }

    public void Load() {
        Debug.Log("Game Loaded!");
        this.speed = PlayerPrefs.GetFloat("chicken-zoomies", 0.05f);
        this.rotation_Speed = PlayerPrefs.GetFloat("chicken-rotation-speed", 1f);
        this.scale_speed = PlayerPrefs.GetFloat("chicken-scale-speed", 0.005f);
        this.zoomies = PlayerPrefs.GetFloat("chicken-zoomies", 0f);
        this.multiplier = PlayerPrefs.GetFloat("multiplier-value", 1f);

        updateZoomies();
        updateMultiplier();
    }
}
