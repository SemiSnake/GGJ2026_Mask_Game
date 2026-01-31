using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private InputAction jumpAction;

    [SerializeField]
    private float jumpHeight = 10f;
    [SerializeField]
    private float movementSpeed = 3f;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        jumpAction = InputSystem.actions.FindAction("Jump");
    }

    void Update()
    {
        Vector2 wishdir = InputSystem.actions.FindAction("Move").ReadValue<Vector2>();
        gameObject.transform.position += new Vector3(wishdir.x,0,0) * Time.deltaTime * movementSpeed;

        if(jumpAction.WasPressedThisFrame())
        {
            rb.linearVelocity = Vector2.up * jumpHeight;
            //rb.AddForce(Vector2.up * jumpHeight);
        }
    }

    private bool isGrounded()
    {
        return false;
    }
}
