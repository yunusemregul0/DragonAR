using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    [SerializeField] private float speed;
    private FixedJoystick joystick;
    private Rigidbody rigidBody;

    private void OnEnable()
    {
        joystick = FindObjectOfType<FixedJoystick>();
        rigidBody = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        var xVal = joystick.Horizontal;
        var yVal = joystick.Vertical;

        Vector3 movement = new Vector3 (xVal, 0, yVal);
        rigidBody.velocity = movement * speed;

        if(xVal != 0 && yVal != 0)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(xVal,yVal)*Mathf.Rad2Deg, transform.eulerAngles.z);
        }
    }
}
