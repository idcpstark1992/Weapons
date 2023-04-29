using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private bool canRun = true;
    [SerializeField] private bool isRunning;
    [SerializeField] private float runSpeed = 9;
    [SerializeField] private KeyCode runningKey = KeyCode.LeftShift;
    private Rigidbody Rb;

    void Awake()=> Rb = GetComponent<Rigidbody>();

    void FixedUpdate()
    {
        isRunning = canRun && Input.GetKey(runningKey);
        float targetMovingSpeed = isRunning ? runSpeed : speed;
        Vector2 m_targetVelocity = new (Input.GetAxis("Horizontal") * targetMovingSpeed, Input.GetAxis("Vertical") * targetMovingSpeed);
        Rb.velocity = transform.rotation * new Vector3(m_targetVelocity.x, Rb.velocity.y, m_targetVelocity.y);
    }


}