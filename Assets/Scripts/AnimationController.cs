using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem;
public class AnimationController : MonoBehaviour
{
    [SerializeField]
    private Sprite idleSprite;

    [SerializeField]
    private Sprite moveSprite1;

    [SerializeField]
    private Sprite moveSprite2;

    [SerializeField]
    private float baseSwitchTime;

    private float switchTimer;

    private Entity self;

    private float walkAmount = 0;

    private void Start()
    {
        self = GetComponent<Entity>();
        GetComponent<SpriteRenderer>().sprite = idleSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 wishdir = InputSystem.actions.FindAction("Move").ReadValue<Vector2>();
        walkAmount += Time.deltaTime * self.movementSpeed * wishdir.magnitude;
        if(wishdir.x < 0)
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        } else if(wishdir.x > 0)
        {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        } else
        {
            GetComponent<SpriteRenderer>().sprite = idleSprite;
        }
    
        if (walkAmount > baseSwitchTime)
        {
            switchSprite();
            walkAmount = 0;
        }
    }

    private void switchSprite()
    {
        Sprite curSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        if (curSprite == moveSprite1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = moveSprite2;
        } else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = moveSprite1;
        }
    }
}
