using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* TODO today
* Destroy(), Destroy with time delay and UI control of Destroy
* Right click mouse for Destroy
* UI Indicator Label
* Switch statement: change painted object
* Colors, sliders to contorl colors
* Empty?
*/
public class NewBehaviourScript : MonoBehaviour
{
    // in unity we have a couple of privacy levels:
    //private Vector3 paintOrigin = new Vector3(5f, 5f, 50f);
    // ^ will not be shown in the unity editor
    //Vector3 paintOrigin = new Vector3(5f, 5f, 50f);
    // ^ will not be shown in the unity editor
    public Vector3 paintOrigin = new Vector3(5f, 5f, 50f);
    private int selectedPaintingObject;
    private float objectLifeTime;
    private bool timedDestoryStatus;
    private float sizeSliderScaler; // between 0.5 and 5
    private float redValue; // between 0.5 and 5
    private float greenValue; // between 0.5 and 5
    private float blueValue; // between 0.5 and 5
                             // Start is called before the first frame update
    void Start()
    {
        objectLifeTime = 5f;
        sizeSliderScaler = 1f; // Added default value so painted objects are visible
        redValue = 0f;
        greenValue = 0f;
        blueValue = 0f;
        //This prints the message below once in the beginning
        Debug.Log("Welcome to IT201");
    }
    // Update is called once per frame
    void Update()
    {
        //This code will be activated every frame
        // this code checks if the mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Mouse Right Clicked");
        }
        // this code checks if the mouse button is released
        // after being pressed down
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Mouse Left Released");
        }
        if (Input.GetMouseButtonUp(1))
        {
            Debug.Log("Mouse Right Released");
        }
        // this code checks if the mouse button is pressed
        if (Input.GetMouseButton(0))
        {
            GameObject test;
            if (selectedPaintingObject == 0)
            {
                test = GameObject.
                CreatePrimitive(PrimitiveType.Sphere);
            }
            else if (selectedPaintingObject == 1)
            {
                test = GameObject.
                CreatePrimitive(PrimitiveType.Cube);
            }
            else if (selectedPaintingObject == 2)
            {
                test = GameObject.
                CreatePrimitive(PrimitiveType.Cylinder);
            }
            else
            {
                test = GameObject.
                CreatePrimitive(PrimitiveType.Sphere);
            }
            test.transform.position =
            Camera.main.ScreenToWorldPoint(
            Input.mousePosition + paintOrigin);
            test.transform.localScale =
            new Vector3(sizeSliderScaler,
            sizeSliderScaler,
            sizeSliderScaler);
            test.transform.parent = this.gameObject.transform;
            test.gameObject.GetComponent<Renderer>().material.color =
            new Color(redValue, //red -- values range from [0,1]
            greenValue, //green [0,1]
            blueValue); //blue [0,1]
            if (timedDestoryStatus)
            {
                Destroy(test,
                objectLifeTime);
            }
            // test is the gameobject I am going to destroy
            // objectLifeTime is the number of seconds it will live
        }
        if (Input.GetMouseButtonDown(1))
        {
            // Destroy the last painted object without using Physics/Raycast
            if (transform.childCount > 0)
            {
                Transform lastChild = transform.GetChild(transform.childCount - 1);
                Destroy(lastChild.gameObject);
            }
        }
    }
    public void OnMouseDown()
    {
        Debug.Log("Main Object is Clicked!");
    }
    public void buttonIsClicked()
    {
        Debug.Log("Button is working. Woohoo");
        //Destroy
        // destroy all the painted objects
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
    public void setRedValue(float value)
    {
        redValue = value;
    }
    public void setGreenValue(float value)
    {
        greenValue = value;
    }
    public void setBlueValue(float value)
    {
        blueValue = value;
    }
    public void sizeSliderChanged(float sizeSliderValue)
    {
        sizeSliderScaler = sizeSliderValue;
    }
    public void dropDownSelected(int selection)
    {
        //Debug.Log("Selection is " + selection);
        selectedPaintingObject = selection;
    }
    public void sliderChanged(float sliderValue)
    {
        objectLifeTime = sliderValue;
    }
    public void toggleChanged(bool status)
    {
        timedDestoryStatus = status;
    }
}