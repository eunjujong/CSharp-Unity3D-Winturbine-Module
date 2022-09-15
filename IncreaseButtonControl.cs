using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class IncreaseButtonControl : MonoBehaviour
{
    // Start is called before the first frame update
    public bool increase;
    public int count;
    
    private TurbineControl turbine_control_script;
    private StopButtonControl stop_button_script;

    void Start()
    {
        increase = false;
        count = -1;
        turbine_control_script = GetComponent<TurbineControl>();
        stop_button_script = GetComponent<StopButtonControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var temp = count;
            if (count <= 3)
            {
                increase = true;
                count++;
            }

            if (count > 3)
            {
                Debug.Log("Max Turbine speed reached.");
            }

            if (stop_button_script.stop || turbine_control_script.min_speed)
            {
                increase = false;
                count = 0;
            }

            if (temp < count) // revoke increase for next speed raise
            {
                increase = false;
            }
        }
    }
    /*
    void Update()
    {
        while (!turbine_control_script.max_speed)
        {
            increase = true;
            count++;
        }

        if (turbine_control_script.max_speed && !stop_button_script.stop)
        {
            Debug.Log("Max Turbine speed reached.");
        }

        if (stop_button_script.stop || turbine_control_script.min_speed)
        {
            increase = false;
            count = 0;
        }
    }*/
}
