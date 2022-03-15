using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;
    public Vector3 offset;
    [SerializeField] float lerpValue;
    
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, lerpValue * Time.deltaTime);
        //transform.LookAt(target);
    }
}   
