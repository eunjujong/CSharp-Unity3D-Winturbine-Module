using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public bool max_speed;
    public bool min_speed;
    public static float MAX_REACHED = 10000f;
    public static float MIN_REACHED = 10f;
    private float curr_time;

    public GameObject start_button;
    public GameObject stop_button;
    public GameObject inc_button;
    public GameObject dec_button;

    private StartButtonControl start_button_script;
    private StopButtonControl stop_button_script;
    private IncreaseButtonControl inc_button_script;
    private DecreaseButtonControl dec_button_script;

    void Start()
    {
        speed = 10f;
        curr_time = 0;
        max_speed = false;
        min_speed = false;

        start_button_script = start_button.GetComponent<StartButtonControl>();
        stop_button_script = stop_button.GetComponent<StopButtonControl>();
        inc_button_script = inc_button.GetComponent<IncreaseButtonControl>();
        dec_button_script = dec_button.GetComponent<DecreaseButtonControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (start_button_script.justStarted)
        {
            transform.Rotate(0, 0, -speed * Time.deltaTime);
            Debug.Log("Turbine speed increasing to: " + speed * Time.deltaTime);
        }

        if (start_button_script.start && !start_button_script.justStarted)
        {
            if (speed >= MAX_REACHED)
            {
                max_speed = true;
                Debug.Log("Max Turbine speed reached: " + speed);
            }
            else if (speed <= MIN_REACHED)
            {
                min_speed = true;
                Debug.Log("Min Turbine speed reached: " + speed);
            }
            else // (speed < MAX_REACHED && speed > MIN_REACHED)
            {
                if (inc_button_script.increase)
                {
                    var nextSpeed = speed + 2500;
                    while (speed < nextSpeed)
                    {
                        curr_time += Time.deltaTime * 0.005f;
                        speed *= curr_time;
                        transform.Rotate(0, 0, -speed);
                        Debug.Log("Turbine speed increasing to: " + speed);
                    }
                }

                if (dec_button_script.decrease)
                {
                    var nextSpeed = speed - 2500;
                    while (speed > nextSpeed)
                    {
                        curr_time -= Time.deltaTime * 0.005f;
                        speed *= curr_time;
                        transform.Rotate(0, 0, -speed);
                        Debug.Log("Turbine speed decreasing to: " + speed);
                    }
                }
            }

            // if reached a speed level, maintain the speed ------> need to add this! // hickup
            transform.Rotate(0, 0, -speed * Time.deltaTime);
        }

        if (stop_button_script.stop)
        {
            while (speed > 0)
            {
                speed -= speed * Time.deltaTime;
                transform.Rotate(0, 0, speed);
                Debug.Log("Turbine speed slowing down to: " + speed);
            }
            speed = 0;
            curr_time = 0;
        }
    }
}
