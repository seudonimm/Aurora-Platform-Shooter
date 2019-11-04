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


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        currentGravity = rb.gravityScale;

    }

    private void Awake()
    {
        controls = new Controls();
        controls.Player.Movement.performed += ctx => Move();

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
        Move();

        flyCooldownInc++;

        if (flyCooldownInc >= flyCooldownMax)
        {
            moveWitch = false;
            rb.gravityScale = currentGravity;
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
