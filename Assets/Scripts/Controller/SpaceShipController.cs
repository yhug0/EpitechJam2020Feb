using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    private Vector2 walkingVector;

    [SerializeField]
    private AnimationCurve headBobing = new AnimationCurve
    (
        new Keyframe(0f, 0f, 0f, 0f),
        new Keyframe(0f, 0.5f, 0f, 5f),
        new Keyframe(0f, 0f, 0f, 0f),
        new Keyframe(1f, 2.5f, 0f, 0f),
        new Keyframe(0f, 0f, 0f, 0f),
        new Keyframe(0f, 0.5f, 0f, 5f)
    );
    [SerializeField] [Header("Head Bobbing impact factor")] private float HeadBobbingFactor = 1;
    [SerializeField] [Header("Speed Factor")] private float speed = 20;
    [SerializeField] [Header("Camera, body")] private GameObject Camera = default(GameObject);

    [SerializeField] [Header("Mouse X sensibility")] private float XSensibility = 1f;
    [SerializeField] [Header("Mouse Y sensibility")] private float Ysensibility = 1f;

    [SerializeField] [Header("Min Y value loocked")] private float MinLoocked = -90f;
    [SerializeField] [Header("Max Y value loocked")] private float MaxLoocked = -90f;
    [SerializeField] [Header("Max velocyty change")] private float maxVelocityChange = 10.0f;


    private float HorizontalAxe = 0.0F;
    private float VerticalAxe = 0.0F;
    private Vector2 MouseMovement = default(Vector2);
    private Rigidbody RigidbodyCorps = null;
    private float CameraYOffSet;

    void Start()
    {
        if (!RigidbodyCorps) RigidbodyCorps = gameObject.GetComponent<Rigidbody>();
        if (!RigidbodyCorps) RigidbodyCorps = gameObject.AddComponent<Rigidbody>();
        CameraYOffSet = Camera.transform.localPosition.y;
    }
    public void Update()
    {
        /*if (walkingVector.Equals(Vector2.zero))
            return;
        var translation = (transform.forward * walkingVector.y + transform.right * walkingVector.x) * Time.deltaTime * speed;
        transform.Translate(translation);*/

        var velocity = RigidbodyCorps.velocity;
		var velocityChange = ((new Vector3(walkingVector.x, 0,walkingVector.y) * speed * Time.deltaTime) - velocity);
        velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
		velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
		velocityChange.y = 0;
        RigidbodyCorps.AddForce(velocityChange, ForceMode.VelocityChange);
    }

    public void OnLook(InputValue value)
    {
        var m_Look = value.Get<Vector2>();
        transform.Rotate(new Vector3(-m_Look.y, m_Look.x, 0) * Time.deltaTime);
    }

    public void OnWalk(InputValue value)
    {
        walkingVector = value.Get<Vector2>();
    }
}
