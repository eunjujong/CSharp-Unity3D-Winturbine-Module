using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class StopButtonControl : MonoBehaviour
{
    // Start is called before the first frame update
    public bool stop;
    
    private StartButtonControl start_button_script;

    void Start()
    {
        stop = false;
        start_button_script = GetComponent<StartButtonControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stop)
        {
            Debug.Log("Fan and Turbine stopped.");
        }
        // restart if the fan and turbine stop
        else if (start_button_script.start)
        {
            stop = false;
        }
        else
        {
            stop = true;
            Debug.Log("Pressed stop button.");
        }
    }
}
