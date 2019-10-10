using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 25;
    [SerializeField] float jump = 15;
	
    [SerializeField] Rigidbody2D rb1;
	[SerializeField] Rigidbody2D rb2;
	
	[SerializeField] bool faceRight;

    [SerializeField] GameObject p1;
    [SerializeField] GameObject p2;

    [SerializeField] bool onGround;
	
	[SerializeField] Collider2D p1Collider;
	[SerializeField] Collider2D p2Collider;
	
	[SerializeField] float dodgeCooldownMax;
	[SerializeField] float dodgeCooldownInc;

    static float player;

    static float player2;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
		faceRight = true;
    }

    // Update is called once per frame
    void Update()
    {
		dodgeCooldownInc++;
		
        player = PlayerState.player;

        player2 = PlayerState2.player;


		//float moveHorizontal = Input.GetAxis("Horizontal");
		//Vector2 move = new Vector2(moveHorizontal, 0);
		if (Input.GetButton("Horizontal_p1"))
		{
			Debug.Log("aHHHHHHHHHHHHHH");
			p1.transform.position += Input.GetAxis("Horizontal_p1") * transform.right * moveSpeed * Time.deltaTime;
			//rb.AddForce(move * moveSpeed);

			if (p1.transform.position.x > 0 && !faceRight)
			{
				p1.transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
				faceRight = true;
			}
			if (p1.transform.position.x < 0 && faceRight)
			{
				p1.transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
				faceRight = false;
			}
		}
		if (Input.GetButton("Jump_p1") && onGround)
		{
			rb1.AddForce(Vector2.up * jump);
		}
		if(Input.GetButton("Dodge")){
			//p1Collider.enabled = false;
			
			Physics2D.IgnoreLayerCollision(8, 11, true);
			Debug.Log("Dodging");
		
			if(dodgeCooldownInc >= dodgeCooldownMax){
				Physics2D.IgnoreLayerCollision(8, 11, false);
				dodgeCooldownInc = 0;
			}
		}
	
   

		//float moveHorizontal = Input.GetAxis("Horizontal");
		//Vector2 move = new Vector2(moveHorizontal, 0);
		if (Input.GetAxis("Horizontal_p2") == 1 || Input.GetAxis("Horizontal_p2") == -1 || Input.GetButton("Horizontal_p2"))
		{
			Debug.Log("right leftds;lkdfj");
			p2.transform.position += Input.GetAxis("Horizontal_p2") * transform.right * moveSpeed * Time.deltaTime;
			//rb.AddForce(move * moveSpeed);

			if (p2.transform.position.x > 0 && !faceRight)
			{
				p2.transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
				faceRight = true;
			}
			if (p2.transform.position.x < 0 && faceRight)
			{
				p2.transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
				faceRight = false;
			}
		}
		if (Input.GetButton("Jump_p2") && onGround)
		{
			rb2.AddForce(Vector2.up * jump);
		}
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }

    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            onGround = false;
        }

    }

}
