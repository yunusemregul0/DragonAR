using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    [SerializeField] private float speed;
    private FixedJoystick movementJoystick; 
    private FixedJoystick rotationJoystick; 
    private Rigidbody rigidBody;
    private GameObject fireEffect;

    private void OnEnable()
    {
        var allJoystikcs = FindObjectsOfType<FixedJoystick>();
        movementJoystick = allJoystikcs[0];
        rotationJoystick = allJoystikcs[1];

        rigidBody = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        var xVal = movementJoystick.Horizontal;
        var yVal = movementJoystick.Vertical;
        var yValOfSecond = rotationJoystick.Vertical;

        Vector3 movement = new Vector3(xVal, yValOfSecond, yVal);
        rigidBody.velocity = movement * speed;

        fireEffect = GameObject.FindWithTag("Fire");
        if (fireEffect is not null)
        {
            var rigidFire = fireEffect.GetComponent<Rigidbody>();
            rigidFire.velocity = movement * speed;
        }

        if (xVal != 0 && yVal != 0)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(xVal, yVal) * Mathf.Rad2Deg, transform.eulerAngles.z);
            if (fireEffect is not null)
            {
                fireEffect.transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(xVal, yVal) * Mathf.Rad2Deg, transform.eulerAngles.z);
            }
        }

    }
}
