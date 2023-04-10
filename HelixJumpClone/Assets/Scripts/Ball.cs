using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
     Rigidbody rb;
    [SerializeField] float jumpForce=150f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce*Time.deltaTime,rb.velocity.z);
        //rb.AddForce(Vector3.up * jumpForce);
    }
}
