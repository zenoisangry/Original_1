using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    Vector3 velocity;
    Rigidbody rb;

    private void Start()
    {
        //if(ha preso il primo power up, get rb)
        rb = GetComponent<Rigidbody>();
    }
    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }
    public void LookAt(Vector3 lookPoint)
    {
        Vector3 height = new Vector3(lookPoint.x, transform.position.y, lookPoint.z);
        transform.LookAt(height);
    }
    public void FixedUpdate()
    {
        rb.MovePosition(rb.position + velocity * Time.deltaTime);
    }
}
