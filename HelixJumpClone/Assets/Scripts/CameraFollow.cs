using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;
    [SerializeField] float smoothSpeed = 0.04f;

    private void Start()
    {
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        Vector3 newPos = Vector3.Lerp(transform.position,target.position + offset, smoothSpeed);
        transform.position = newPos;
    }



}
