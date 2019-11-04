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


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

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
        rb.gravityScale = 0;
    }
}
