using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float jump;
    [SerializeField] Rigidbody2D rb;
	
	[SerializeField] bool faceRight;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
		faceRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //Vector2 move = new Vector2(moveHorizontal, 0);
        if (Input.GetButton("Horizontal_p1"))
        {
            transform.position += Input.GetAxis("Horizontal_p1") * transform.right * moveSpeed * Time.deltaTime;
            //rb.AddForce(move * moveSpeed);
			
			if(transform.position.x > 0 && !faceRight){
				transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                faceRight = true;
			}
			if(transform.position.x < 0 && faceRight){
				transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                faceRight = false;
			}
        }
        if (Input.GetButton("Jump_p1"))
        {
            rb.AddForce(Vector2.up * jump);
        }
        
    }
}
