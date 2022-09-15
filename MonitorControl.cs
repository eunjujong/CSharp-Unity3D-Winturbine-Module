using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class MonitorControl : MonoBehaviour
{    
    private float speed;
    private float currSpeed;
    public static readonly float[] speedVals = new float[4] { 5.6f, 6.6f, 7.1f, 8.3f }; 
    public static readonly string[] speedLevels = new string[4] { "Low", "Medium", "High", "Extremely High" };
    public Text speedLabel;

    public Rigidbody turbine;

    //private StartButtonControl start_button_script;
    //private TurbineControl turbine_control_script;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = turbine.velocity.magnitude; // m/s --> * 3.6f to convert to km/h
        if (speedLabel != null)
        {
            if (speed <= 2510f)
            {
                speedLabel.text = "Turbine Speed: " + speedLevels[0] + " ---> " + speedVals[0].ToString("F3") + " m/s";
            }
            else if (speed > 2510f && speed <= 5010f)
            {
                speedLabel.text = "Turbine Speed: " +  + speedLevels[1] + " ---> " + speedVals[1].ToString("F3") + " m/s";
            }
            else if (speed > 5010f && speed <= 7510f)
            {
                speedLabel.text = "Turbine Speed: " +  + speedLevels[2] + " ---> " + speedVals[2].ToString("F3") + " m/s";
            }
            else(speed > 7510f)
            {
                speedLabel.text = "Turbine Speed: " +  + speedLevels[3] + " ---> " + speedVals[3].ToString("F3") + " m/s";
            }
        }
    }
}
