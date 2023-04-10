using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMove : MonoBehaviour
{
    [SerializeField] public float rotateSpeed = 200f;
    [SerializeField] public float rotateSpeedMobile = 60f;
    private float moveX;

    
    void Update()
    {
     #if UNITY_EDITOR
        //for pc
        if (Input.GetMouseButton(0))
        {
            moveX = Input.GetAxis("Mouse X"); //or use raw
            transform.Rotate(transform.position.x, moveX*rotateSpeed*Time.deltaTime,transform.position.z);
        }
     #elif UNITY_ANDROID
        //for mobile
        if (Input.touchCount >0 && Input.GetTouch(0).phase ==TouchPhase.Moved)
        {
            float xDeltaPos = Input.GetTouch(0).deltaPosition.x;
            transform.Rotate(transform.position.x, xDeltaPos * rotateSpeedMobile * Time.deltaTime, transform.position.z);

        }
     #endif

    }
}
