using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FanController : MonoBehaviour
{
    private bool start; // start rotation - default
    private bool stop; // stop rotation
    private bool increase; // increase speed
    private bool decrease; // decrease speed
    public GameObject fanObject;

    Rigidbody rb;

    void Start()
    {
        start = false;
        stop = false;
        increase = false;
        decrease = false;
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (start) // fanObject.GetComponent<ButtonControlStart>().isPressed
        {
            rb.velocity = rb.velocity * 1.1; // default speed when starting
            rb.angularVelocity = rb.angularVelocity * 1.1; // default rotation
        }
        if (increase) // fanObject.GetComponent<ButtonControlIncrease>().isPressed
        {
            rb.AddForce(fanObject.GetComponent<FanRotation>().IncreaseSpeed);
        }
        if (decrease) // fanObject.GetComponent<ButtonControlDecrease>().isPressed
        {
            rb.AddForce(fanObject.GetComponent<FanRotation>().DecreaseSpeed);
        }
        if (stop) // fanObject.GetComponent<ButtonControlStop>().isPressed
        {
            rb.velocity = rb.velocity * 0.95 * Time.deltaTime; // slow down translating/moving until stop
            rb.angularVelocity = rb.angularVelocity * 0.95 * Time.deltaTime; // slow down rotating until stop
        }
    }

    //void Update()
    //{

    //}

    private void Start()
    {
        start = GameObject.Find("button").GetComponent<ButtonControlStart>().isPressed;
    }

    private void Stop()
    {
        stop = GameObject.Find("button").GetComponent<ButtonControlStop>().isPressed;
    }

    private void Increase()
    {
        increase = GameObject.Find("button").GetComponent<ButtonControlIncrease>().isPressed;
    }

    private void Descrease()
    {
        decrease = GameObject.Find("button").GetComponent<ButtonControlDecrease>().isPressed;
    }


    //private void ExecuteTrigger(string trigger)
    //{
    //    if(Box != null)
    //    {
    //        var animator = Box.GetComponent<Animator>();
    //        if(animator != null)
    //        {
    //            animator.SetTrigger(trigger);
    //        }
    //    }
    //}

    //private void OnOpenButtonClick()
    //{
    //    ExecuteTrigger("TrOpen");
    //}

    //private void OnCloseButtonClick()
    //{
    //    ExecuteTrigger("TrClose");
    //}
}