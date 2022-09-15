using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedMonitor : MonoBehaviour
{
    private float speed;
    public GameObject monitorObject;
    public Text textOne;
    public Text textTwo;

    [SerializedField] Text speedDisplayText;
    [SerializedField] Text speedDisplayText2;

    // need additional adjustment according to the display on Unity3D
    void start()
    {
        textOne.text = "Fan Speed: ";
        textOne.text = "Turbine Speed: ";
        speedDisplayText.text = monitorObject.GetComponent<FanRotation>().speed.ToString("F3");
        speedDisplayText2.text = monitorObject.GetComponent<TurbineRotation>().speed.ToString("F3");
    }
}
