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
		if (Input.GetButton("Jump_p1"))
		{
			rb1.AddForce(Vector2.up * jump);
		}
	
   

		//float moveHorizontal = Input.GetAxis("Horizontal");
		//Vector2 move = new Vector2(moveHorizontal, 0);
		if (Input.GetAxis("Horizontal_p2") ==+ 1 || Input.GetAxis("Horizontal_p2") == -1)
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
		if (Input.GetButton("Jump_p2"))
		{
			rb2.AddForce(Vector2.up * jump);
		}
        
    }
}
