using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;


public class ProjectileAttack : MonoBehaviour {

    // Use this for initialization
    [SerializeField] float speed;
	
	[SerializeField] GameObject projectile1;
	[SerializeField] GameObject projectile2;
    [SerializeField] Transform projectileSpawn;
	
	[SerializeField] Rigidbody2D rb;
	
	[SerializeField] float cooldownMax;
	[SerializeField] float coolddownInc;

	string fire = null;
    static float player;
	
	Vector2 direction;
	void Start () {
		//Debug.Log();

        /*bool projDir = GameObject.Find("Player").GetComponent<PlayerMovement>().faceRight;

        if (projDir)
        {
            GetComponent<Rigidbody2D>().velocity = transform.right * speed;
        }
        else {
            GetComponent<Rigidbody2D>().velocity = transform.right * speed * -1;
        }*/
		
		
		//GetComponent<Rigidbody2D>().velocity = transform.right * speed;
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

	
	// Update is called once per frame
	void Update () {
		
		coolddownInc++;
		
		Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (Vector2)((worldMousePos - transform.position));
        direction.Normalize();
		
		
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;


		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		
		//transform.rotation = direction;
		
		
	}
	

}
