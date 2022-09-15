using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurbineController : MonoBehaviour
{
    public GameObject turbineObject;

    Rigidbody rb;

    //void Start()
    //{

    //}

    //void Update()
    //{

    //}

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (turbineObject.GetComponent<FanController>().start)
        {
            rb.velocity = rb.velocity * 1.15; // default speed when starting
            rb.angularVelocity = rb.angularVelocity * 1.15; // default rotation
        }
        if (turbineObject.GetComponent<FanController>().horizontal)
        {
            if (turbineObject.GetComponent<FanController>().increase)
            {
                rb.AddForce(turbineObject.GetComponent<TurbineRotation>().HorizontalIncreaseSpeed);
            }
            if (turbineObject.GetComponent<FanController>().decrease)
            {
                rb.AddForce(turbineObject.GetComponent<TurbineRotation>().HorizontalDecreaseSpeed);
            }
        }

        if (turbineObject.GetComponent<FanController>().vertical)
        {
            if (turbineObject.GetComponent<FanController>().increase)
            {
                rb.AddForce(turbineObject.GetComponent<TurbineRotation>().VerticalIncreaseSpeed);
            }
            if (turbineObject.GetComponent<FanController>().decrease)
            {
                rb.AddForce(turbineObject.GetComponent<TurbineRotation>().VerticalDecreaseSpeed);
            }
        }

        if (turbineObject.GetComponent<FanController>().stop)
        {
            rb.velocity = rb.velocity * 0.9 * Time.deltaTime; /// slow down translating/moving until stop
            rb.angularVelocity = rb.angularVelocity * 0.9 * Time.deltaTime; // slow down rotating until stop
        }
    }
}