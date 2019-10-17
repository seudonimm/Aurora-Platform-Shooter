using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

[RequireComponent(typeof(CharacterController))]
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
	
	float dodgeCooldownMax = 100;
	float dodgeCooldownInc = 0;

    //static float player;

    //static float player2;
	
	private Player player1;
	private Player player2;
	private CharacterController cc;
	private Vector3 moveVector;
	[SerializeField] Vector3 moveVector2;
	
	[SerializeField] float shotSpeed;
	
	[SerializeField] GameObject projectile1;
	[SerializeField] GameObject projectile2;
    [SerializeField] Transform projectileSpawn;
	
	[SerializeField] float cooldownMax;
	[SerializeField] float coolddownInc;



	

    // Start is called before the first frame update
    void Start()
    {
		player1 = ReInput.players.GetPlayer(0);
		player2 = ReInput.players.GetPlayer(1);
			
        //rb = GetComponent<Rigidbody2D>();
		faceRight = true;
    }
	
	void GetInput(){
		moveVector.x = player1.GetAxis("Move Horizontal");	
		
		moveVector2.x = player2.GetAxis("Move Horizontal");
		
		
		//moveVector.x = player2.GetAxis("Move Horizontal");	

	}
			
		
	void Fire(){

		if(coolddownInc >= cooldownMax){
			if(player1.GetButton("Charge Shot")){
				Instantiate(projectile1, projectileSpawn.position, projectileSpawn.rotation);
				coolddownInc = 0;

			}
			if(player1.GetButton("HP Shot")){
				Instantiate(projectile2, projectileSpawn.position, projectileSpawn.rotation);
				coolddownInc = 0;
			}
		}
		
	}		
	
	void Fire2(){

		if(coolddownInc >= cooldownMax){
			if(player2.GetButton("Charge Shot")){
				Instantiate(projectile1, projectileSpawn.position, projectileSpawn.rotation);
				coolddownInc = 0;

			}
			if(player2.GetButton("HP Shot")){
				Instantiate(projectile2, projectileSpawn.position, projectileSpawn.rotation);
				coolddownInc = 0;
			}
		}
		
	}		

	
	void ProcessInput2(){
		if(moveVector2.x > 0){
			p2.transform.position += transform.right * moveSpeed * Time.deltaTime;
		}
		if(moveVector2.x < 0){
			p2.transform.position += -transform.right * moveSpeed * Time.deltaTime;
		}
		
		if(player2.GetButtonDown("Jump") && onGround == true){
			rb2.AddForce(Vector2.up * jump);
		}
		
	}

	
	void ProcessInput(){
		if(moveVector.x > 0){
			p1.transform.position += transform.right * moveSpeed * Time.deltaTime;
		}
		if(moveVector.x < 0){
			p1.transform.position += -transform.right * moveSpeed * Time.deltaTime;
		}
		if(player1.GetButtonDown("Jump") && onGround == true){
			rb1.AddForce(Vector2.up * jump);
		}

		
	}

    // Update is called once per frame
    void Update()
    {
		GetInput();
		ProcessInput();
		ProcessInput2();
		Fire();
		Fire2();
		
		coolddownInc++;

		
		/*dodgeCooldownInc++;
		
        //player = PlayerState.player;

        //player2 = PlayerState2.player;


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
		}
		
		if(dodgeCooldownInc > dodgeCooldownMax ){
			//p1Collider.enabled = false;
			
			Debug.Log(dodgeCooldownInc);
			Debug.Log(dodgeCooldownMax);

			Physics2D.IgnoreLayerCollision(8, 11, false);

			dodgeCooldownInc = 0;
		}

		

		if (Input.GetAxis("Horizontal_p2") == 1 || Input.GetAxis("Horizontal_p2") == -1 || Input.GetButton("Horizontal_p2"))
		{
			//Debug.Log("right leftds;lkdfj");
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
        */
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

