using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class StartButtonControl : MonoBehaviour
{
    // Start is called before the first frame update
    public bool start;
    public bool justStarted;
    
    private StopButtonControl stop_button_script;

    void Start()
    {
        start = false;
        justStarted = false;
        stop_button_script = GetComponent<StopButtonControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (start)
            {
                justStarted = false;
                Debug.Log("Fan and Turbine in rotation.");
            }
            // restart if the fan and turbine stop
            else if (stop_button_script.stop)
            {
                start = false;
                justStarted = false;
            }
            else
            {
                start = true;
                justStarted = true;
                Debug.Log("Pressed start button.");
            }
        }
    }
    /*
    void TriggerStart()
    {
        if (start)
        {
            start = false;
        }
        else
        {
            start = true;
        }
        start_button.SetActive(start);
    }*/
}
