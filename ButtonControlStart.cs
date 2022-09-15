using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ButtonControlStart : MonoBehaviour
{
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    GameObject presser;
    AudioSource sound;
    public bool isPressed;

    void Start()
    {
        sound = GetComponent<AudioSource>();
        isPressed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            button.transform.localPosition new Vector3(0, 0.7f, 0);
            presser = other.gameObject;
            onPress.Invoke();
            sound.Play();
            isPressed = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser)
        {
            button.transform.localPosition new Vector3(0, 0.1f, 0);
            onRelease.Invoke();
            isPressed = false;
        }
    }

    private void buttonSphere()
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        sphere.transform.localPosition = new Vector3(0, 1, 2);
        sphere.AddComponent<Rigidbody>();
    }
}

//public Rigidbody buttonTopRigid;
//public Transform buttonTop;
//public Transform buttonLowerLimit;
//public Transform buttonUpperLimit;
//public float threshHold;
//public float force = 10;
//private float upperLowerDiff;
//public bool isPressed;
//private bool prevPressedState;
//public UnityEvent onPressed;
//public UnityEvent onReleased;

//void Start()
//{
//    if (transform.eulerAngles != Vector3.zero)
//    {
//        Vector3 savedAngle = transform.eulerAngles;
//        transform.eulerAngles = Vector3.zero;
//        upperLowerDiff = buttonUpperLimit.position.y - buttonLowerLimit.position.y;
//        transform.eulerAngles = savedAngle;
//    }
//    else
//        upperLowerDiff = buttonUpperLimit.position.y - buttonLowerLimit.position.y;
//}

//void Update()
//{
//    buttonTop.transform.localPosition = new Vector3(0, buttonTop.transform.localPosition.y, 0);
//    buttonTop.transform.localEulerAngles = new Vector3(0, 0, 0);
//    if (buttonTop.localPosition.y >= 0)
//        buttonTop.transform.position = new Vector3(buttonUpperLimit.position.x, buttonUpperLimit.position.y, buttonUpperLimit.position.z);
//    else
//        buttonTopRigid.AddForce(buttonTop.transform.up * force * Time.deltaTime);

//    if (buttonTop.localPosition.y <= buttonLowerLimit.localPosition.y)
//        buttonTop.transform.position = new Vector3(buttonLowerLimit.position.x, buttonLowerLimit.position.y, buttonLowerLimit.position.z);


//    if (Vector3.Distance(buttonTop.position, buttonLowerLimit.position) < upperLowerDiff * threshHold)
//        isPressed = true;
//    else
//        isPressed = false;

//    if (isPressed && prevPressedState != isPressed)
//        Pressed();
//    if (!isPressed && prevPressedState != isPressed)
//        Released();
//}

//void Pressed()
//{
//    prevPressedState = isPressed;
//    pressedSound.pitch = 1;
//    pressedSound.Play();
//    onPressed.Invoke();
//}

//void Released()
//{
//    prevPressedState = isPressed;
//    releasedSound.pitch = Random.Range(1.1f, 1.2f);
//    releasedSound.Play();
//    onReleased.Invoke();
//}