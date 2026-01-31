using Unity.Mathematics;
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

    private bool touchingGround;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        jumpAction = InputSystem.actions.FindAction("Jump");
    }

    void Update()
    {
        Vector2 wishdir = InputSystem.actions.FindAction("Move").ReadValue<Vector2>();
        gameObject.transform.position += new Vector3(wishdir.x,0,0) * Time.deltaTime * movementSpeed;

        if(jumpAction.WasPressedThisFrame() && isGrounded())
        {
            rb.linearVelocity = Vector2.up * jumpHeight;
            touchingGround = false;
        }
    }

    private bool isGrounded()
    {
        if(math.abs(rb.linearVelocityY) < 0.1 && touchingGround) {
            return true;
        } else {
            return false;
        }

    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.tag == "Ground")
        {
            touchingGround = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            touchingGround = true;
        }
    }
}
