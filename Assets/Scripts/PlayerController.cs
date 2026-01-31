using Unity.Mathematics;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Entity
{
    private Rigidbody2D rb;
    private InputAction jumpAction;
    private InputAction attackAction;
    private GameObject cam;

    [SerializeField]
    private float jumpHeight = 10f;
    [SerializeField]
    private float movementSpeed = 3f;

    private float attackCooldown = 1f;
    private float attackTimer = 0f;
    private bool touchingGround;
    private void Awake() {
     
    }
    void Start()
    {
        cam = Camera.main.gameObject;
        cam.GetComponent<CameraController>().setActivePlayer(gameObject);
        rb = gameObject.GetComponent<Rigidbody2D>();
        jumpAction = InputSystem.actions.FindAction("Jump");
        attackAction = InputSystem.actions.FindAction("Attack");
    }

    void Update()
    {
        Vector2 wishdir = InputSystem.actions.FindAction("Move").ReadValue<Vector2>();
        gameObject.transform.position += new Vector3(wishdir.x,0,0) * Time.deltaTime * movementSpeed;

        if(jumpAction.IsPressed() && isGrounded())
        {
            rb.linearVelocity = Vector2.up * jumpHeight;
        }

        if (attackAction.WasPressedThisFrame() && attackTimer <= 0)
        {
            AttackManager.performAttack(this, "Enemy");
            attackTimer = attackCooldown;
        }
        attackTimer -= Time.deltaTime;
    }

    private bool isGrounded()
    {
        if(math.abs(rb.linearVelocityY) < 0.1 /*&& touchingGround*/) {
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

    public override void Die()
    {
        GameManager.StartGame();
    }
}
