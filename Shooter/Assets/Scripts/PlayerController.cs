using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float moveSpeed = 15f;
    [SerializeField] float jumpHeight = 1000f;
    [SerializeField] Rigidbody2D rb;

    private Controls controls = null;

    [SerializeField] Vector2 rightLeft;

    [SerializeField] bool moveWitch = false;
    [SerializeField] bool moveChef = false;


    [SerializeField] float flyCooldownMax;
    [SerializeField] float flyCooldownInc;

    [SerializeField] float currentGravity;

    [SerializeField] float explosionSpeed;
    [SerializeField] Transform explosionSpawn;
    [SerializeField] GameObject explosion;

    [SerializeField] int playerID;

    [SerializeField] Transform player;

    [SerializeField] bool moveRight;
    [SerializeField] bool moveLeft;
    [SerializeField] bool moveUp;
    [SerializeField] bool moveDown;




    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        currentGravity = rb.gravityScale;


    }

    private void Awake()
    {
        controls = new Controls();

        //controls.Player.Movement.performed += ctx => Move();

    }

    private void OnEnable()
    {
        controls.Player.Enable();
    }
    private void OnDisable()
    {
        controls.Player.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        //Move();

        var movementInput = controls.Player.Movement.ReadValue<Vector2>();



        flyCooldownInc++;

        if (flyCooldownInc >= flyCooldownMax)
        {
            moveWitch = false;
            rb.gravityScale = currentGravity;
        }

        if (moveRight)
        {
            transform.position += transform.right * moveSpeed * Time.deltaTime;

        }
        if (moveLeft)
        {
            transform.position += -transform.right * moveSpeed * Time.deltaTime;

        }
        if (moveWitch)
        {
            if (moveUp)
            {
                transform.position += transform.up * moveSpeed * Time.deltaTime;
            }
            if (moveDown)
            {
                transform.position += -transform.up * moveSpeed * Time.deltaTime;
            }
        }


    }

    public void allowMovement()
    {
        var movementInput = controls.Player.Movement.ReadValue<Vector2>();

        rightLeft = movementInput;

        Debug.Log(movementInput);

        if (movementInput.x > 0)
        {
            moveRight = true;
        }
        else
        {
            moveRight = false;
        }

        if (movementInput.x < 0)
        {
            moveLeft = true;
        }
        else
        {
            moveLeft = false;
        }

        if (movementInput.y > 0)
        {
            moveUp = true;
        }
        else
        {
            moveUp = false;
        }

        if (movementInput.y < 0)
        {
            moveDown = true;
        }
        else
        {
            moveDown = false;
        }

    }

    public void Move()
    {
        var movementInput = controls.Player.Movement.ReadValue<Vector2>();

        rightLeft = movementInput;

        if (movementInput.x > 0)
        {
            transform.position += transform.right * moveSpeed * Time.deltaTime;
        }
        if (movementInput.x < 0)
        {
            transform.position += -transform.right * moveSpeed * Time.deltaTime;
        }
        if (moveWitch)
        {
            if (movementInput.y > 0)
            {
                transform.position += transform.up * moveSpeed * Time.deltaTime;
            }
            if (movementInput.y < 0)
            {
                transform.position += -transform.up * moveSpeed * Time.deltaTime;
            }
        }

    }
    public void Jump()
    {
        rb.AddForce(Vector2.up * jumpHeight);

        Debug.Log("new jump");

    }

    public void ChefSpecial()
    {
        float slideSpeed = 1000;

        if (rightLeft.x > 0)
        {
            rb.AddForce(Vector2.right * slideSpeed);
        }
        if (rightLeft.x < 0)
        {
            rb.AddForce(-Vector2.right * slideSpeed);
        }

        Debug.Log("slide");
    }

    public void WitchSpecial()
    {
        moveWitch = true;

        rb.gravityScale = 0;

        flyCooldownInc = 0;

    }

    public void PirateSpecial()
    {
        Instantiate(explosion, explosionSpawn.position, explosionSpawn.rotation);
        rb.AddForce(rightLeft * explosionSpeed);
    }

    public void SpySpecial()
    {

    }
}
