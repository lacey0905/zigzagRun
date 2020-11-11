using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour
{

    Vector3 direction = Vector3.forward;
    int groundCheck = 2;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            direction = Vector3.forward;
        }
        else if (Input.GetMouseButtonDown(1))
        {
            direction = Vector3.right;
        }

        Debug.Log(groundCheck);
        
    }

    void FixedUpdate()
    {
        groundCheck = GroundCheck(direction);
    }

    public float margin = 0.5f;

    private int GroundCheck(Vector3 direction)
    {
        Quaternion rotate = Quaternion.AngleAxis(90f, Vector3.up);
        Vector3 origin = rotate * direction * margin;

        RaycastHit left, right;

        bool leftHit = Physics.Raycast(transform.position + (Vector3.up * 0.5f) + origin, -Vector3.up, out left, 1f);
        bool RightHit = Physics.Raycast(transform.position + (Vector3.up * 0.5f) - origin, -Vector3.up, out right, 1f);

        Debug.DrawRay(transform.position + (Vector3.up * 0.5f) + origin, -Vector3.up, leftHit ? Color.green : Color.red);
        Debug.DrawRay(transform.position + (Vector3.up * 0.5f) - origin, -Vector3.up, RightHit ? Color.green : Color.red);

        if (leftHit && RightHit) return 2;
        else if (leftHit || RightHit) return 1;
        else return 0;

    }

}
