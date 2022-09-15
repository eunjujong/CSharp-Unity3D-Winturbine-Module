using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class DecreaseButtonControl : MonoBehaviour
{
    // Start is called before the first frame update
    public bool decrease;
    public int count;
    
    private TurbineControl turbine_control_script;
    private StopButtonControl stop_button_script;

    void Start()
    {
        decrease = false;
        count = 0;
        turbine_control_script = GetComponent<TurbineControl>();
        stop_button_script = GetComponent<StopButtonControl>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var temp = count;
            if (count <= 3)
            {
                decrease = true;
                count++;
            }

            if (count > 3)
            {
                Debug.Log("Max Turbine speed reached.");
            }

            if (stop_button_script.stop || turbine_control_script.min_speed)
            {
                decrease = false;
                count = 0;
            }

            if (temp < count)
            {
                decrease = false; // revoke decrease for next speed fall
            }
        }
    }

    /*
    // Update is called once per frame
    void Update()
    {
        while (!turbine_control_script.min_speed)
        {
            decrease = true;
            count++;
        }

        if (turbine_control_script.min_speed && !stop_button_script.stop)
        {
            Debug.Log("Min Turbine speed reached.");
        }

        if (stop_button_script.stop || turbine_control_script.max_speed)
        {
            decrease = false;
            count = 0;
        }
    }*/
}
