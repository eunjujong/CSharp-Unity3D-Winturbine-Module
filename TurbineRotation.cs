using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurbineRotation : MonoBehaviour
{
    public float speed;
    private int index;
    private static readonly float[] fanSpeed = new float[4] { 300f, 600f, 900f, 1200f };
    private static readonly string[] speedLevel = new string[4] { "Low", "Medium", "High", "Extremely High" };

    void Start()
    {
        speed = 0f;
        index = 0;
    }

    public void HorizontalIncreaseSpeed()
    {
        while (speed < fanSpeed[index + 1])
        {
            speed += fanSpeed[index] * Time.FixedDeltaTime;
            transform.Rotate(-speed, 0, 0, Space.World);
            Debug.Log("Fan Speed: " + speed.ToString("F3"));
        }
        Debug.Log(speedLevel[index] + " speed reached.");
        index++;
    }

    public void VirticalIncreaseSpeed()
    {
        while (speed < fanSpeed[index + 1])
        {
            speed += fanSpeed[index] * Time.FixedDeltaTime;
            transform.Rotate(0, -speed, 0, Space.World);
            Debug.Log("Fan Speed: " + speed.ToString("F3"));
        }
        Debug.Log(speedLevel[index] + " speed reached.");
        index++;
    }

    public void HorizontalDecreaseSpeed()
    {
        index--;
        while (speed >= fanSpeed[index])
        {
            speed -= fanSpeed[index] * Time.FixedDeltaTime;
            transform.Rotate(-speed, 0, 0, Space.World);
            Debug.Log("Fan Speed: " + speed.ToString("F3"));
        }
        Debug.Log(speedLevel[index] + " speed reached.");
    }

    public void VirticalDecreaseSpeed()
    {
        index--;
        while (speed >= fanSpeed[index])
        {
            speed -= fanSpeed[index] * Time.FixedDeltaTime;
            transform.Rotate(0, -speed, 0, Space.World);
            Debug.Log("Fan Speed: " + speed.ToString("F3"));
        }
        Debug.Log(speedLevel[index] + " speed reached.");
    }
}