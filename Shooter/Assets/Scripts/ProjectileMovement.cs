using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;


public class ProjectileMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D rb;

    Vector2 direction;

    //[SerializeField] int playerID;

    //private Player player;
    //private Player player2;
    //public Vector2 aimVector;



    // Start is called before the first frame update
    void Start()
    {
        //player = ReInput.players.GetPlayer(playerID);
        //player2 = ReInput.players.GetPlayer(1);

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;

        //GetInput();

        //direction = aimVector;


        //Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //direction = (Vector2)((worldMousePos - transform.position));
        //direction.Normalize();
    }

    // Update is called once per frame
    void Update()
    {


       // rb.velocity = transform.right * speed;



    }

    void GetInput()
    {
        //aimVector.x = player.GetAxis("Aim Horizontal");

        //aimVector.y = player.GetAxis("Aim Vertical");

    }
    void ProcessInput()
    {
        //float joyAngle = Mathf.Atan2(aimVector.y, aimVector.x) * Mathf.Rad2Deg;
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
