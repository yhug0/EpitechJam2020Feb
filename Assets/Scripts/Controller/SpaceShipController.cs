using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    private Vector2 walkingVector;
    private Vector2 Look;
    [SerializeField] [Header("Speed Factor")] private float speed = 20;
    [SerializeField] [Header("Camera, body")] private GameObject Camera = default(GameObject);

    [SerializeField] [Header("Mouse X sensibility")] private float XSensibility = 1f;
    [SerializeField] [Header("Mouse Y sensibility")] private float Ysensibility = 1f;
    private Rigidbody RigidbodyCorps = null;
    private float CameraYOffSet;

    void Start()
    {
        if (!RigidbodyCorps) RigidbodyCorps = gameObject.GetComponent<Rigidbody>();
        if (!RigidbodyCorps) RigidbodyCorps = gameObject.AddComponent<Rigidbody>();
        CameraYOffSet = Camera.transform.localPosition.y;
        RigidbodyCorps.useGravity = false;
    }
    public void Update()
    {
		var velocityChange = (((walkingVector.y * transform.forward) * speed * Time.deltaTime));
        RigidbodyCorps.AddForce(velocityChange, ForceMode.VelocityChange);
        Rotate();
    }

    public void Rotate()
    {
         var rotation = transform.rotation.eulerAngles;
        RigidbodyCorps.AddTorque((transform.right * - Look.y * Ysensibility + transform.up * Look.x * XSensibility + walkingVector.x * transform.forward * speed)* Time.deltaTime);
    }

    public void OnLook(InputValue value)
    {
        Look = value.Get<Vector2>();
    }

    public void OnWalk(InputValue value)
    {
        walkingVector = value.Get<Vector2>();
    }

    public void OnBreak()
    {
        RigidbodyCorps.velocity  /= 2;
        RigidbodyCorps.angularVelocity /= 2;
        
    }
}
