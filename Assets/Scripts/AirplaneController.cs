
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AirplaneController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float forwardSpeed = 8f;
    public float turnSpeed = 65f;
    public float climbSpeed = 4f;

    [Header("Takeoff Settings")]
    public float takeoffHeight = 3f;

    // Xac dinh may bay da cat canh hay chua
    public bool HasTakenOff { get; private set; }

    private Rigidbody rb;

    private bool moveForward;
    private bool climb;
    private float turnInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Doc phim dieu khien
        moveForward = Input.GetKey(KeyCode.W);
        climb = Input.GetKey(KeyCode.Space);

        turnInput = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            turnInput += 1f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            turnInput -= 1f;
        }
    }

    void FixedUpdate()
    {
        if (!moveForward)
            return;

        float deltaTime = Time.fixedDeltaTime;

        // Xoay may bay
        Quaternion newRotation = rb.rotation *
            Quaternion.Euler(
                0f,
                turnInput * turnSpeed * deltaTime,
                0f
            );

        rb.MoveRotation(newRotation);

        // Dau may bay hien tai huong ve -Z
        Vector3 forwardDirection =
            -(newRotation * Vector3.forward);

        Vector3 movement =
            forwardDirection * forwardSpeed * deltaTime;

        // Cat canh khi giu W va Space
        if (climb)
        {
            movement +=
                Vector3.up * climbSpeed * deltaTime;
        }

        rb.MovePosition(rb.position + movement);

        // Kiem tra da dat do cao cat canh
        if (rb.position.y + movement.y >= takeoffHeight)
        {
            HasTakenOff = true;
        }
    }
}
