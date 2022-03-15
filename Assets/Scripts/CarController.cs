using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float Traction;

    float dragAmount = 0.99f;

    [SerializeField] float steerAngle;

    public Transform lWhell, rWhell;

    private Vector3 _rotVec;

    private Vector3 _moveVec;

    void Update()
    {
        //speed = Mathf.Lerp(speed, maxSpeed, lerpValue);
        _moveVec += transform.forward * speed * Time.deltaTime;
        _rotVec += new Vector3(0f, Input.GetAxis("Horizontal"), 0f);


        transform.position += _moveVec * Time.deltaTime;
        

        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * steerAngle * Time.deltaTime * _moveVec.magnitude);

        _moveVec *= dragAmount;
        _moveVec = Vector3.ClampMagnitude(_moveVec, maxSpeed);
        _moveVec = Vector3.Lerp(_moveVec.normalized, transform.forward, Traction * Time.deltaTime)*_moveVec.magnitude;
        _rotVec = Vector3.ClampMagnitude(_rotVec, steerAngle);

        lWhell.localRotation = Quaternion.Euler(_rotVec);
        rWhell.localRotation = Quaternion.Euler(_rotVec);
    }
}
