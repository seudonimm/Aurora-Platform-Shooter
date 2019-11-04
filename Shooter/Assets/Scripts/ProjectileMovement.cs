using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Rewired;


public class ProjectileMovement : MonoBehaviour
{
	[SerializeField] float speed;
	[SerializeField] Rigidbody2D rb;
	
	Vector2 direction;

    //[SerializeField] int playerID;

    //private Player player;

    public Vector2 aimVector;

    private Controls controls = null;


    // Start is called before the first frame update
    private void Awake()
    {
        controls = new Controls();

        //GetInput();

    }
    void Start()
    {
        //player = ReInput.players.GetPlayer(playerID);

        rb = GetComponent<Rigidbody2D>();

        //GetInput();

        direction = aimVector;

        //rb.velocity = aimVector * speed;



        //Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //direction = (Vector2)((worldMousePos - transform.position));
        //direction.Normalize();
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
        //GetInput();
        //ProcessInput();
		 
        rb.velocity = transform.right * speed;

		
		
    }

    void GetInput()
    {
        aimVector = controls.Player.Aim.ReadValue<Vector2>();
     

    }
    void ProcessInput()
    {
        float joyAngle = Mathf.Atan2(aimVector.y, aimVector.x) * Mathf.Rad2Deg;
        //projectileSpawn.rotation = Quaternion.AngleAxis(joyAngle, Vector3.forward);


    }


    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }

    }
}
