using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanRotation : MonoBehaviour
{
    public float speed;
    private int index;
    private static readonly float[] fanSpeed = new float[4] { 200f, 400f, 600f, 800f };
    private static readonly string[] speedLevel = new string[4] { "Low", "Medium", "High", "Extremely High" };

    void Start()
    {
        speed = 0f;
        index = 0;
    }

    //void Update()
    //{

    //}

    public void IncreaseSpeed()
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

    public void DecreaseSpeed()
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