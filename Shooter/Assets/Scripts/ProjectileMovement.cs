using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
	[SerializeField] float speed;
	[SerializeField] Rigidbody2D rb;
	
	Vector2 direction;
	
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
		
						
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (Vector2)((worldMousePos - transform.position));
        direction.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
		

		 
        rb.velocity = direction * speed;
		
		
    }
	
	    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }

    }
}
