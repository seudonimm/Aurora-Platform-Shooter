using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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



	
	// Update is called once per frame
	void Update () {
		
		coolddownInc++;
		
		Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (Vector2)((worldMousePos - transform.position));
        direction.Normalize();
		
		
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		//Debug.Log(angle);
		
		/*omni directional setup
		//0 degree
		if(angle > - 22.5  && angle <= 22.5){
			angle = 0;
		}
		//45 degree
		else if(angle > 22.5  && angle <= 67.5){
			angle = 45;
		}
		//90 degree		
		else if(angle > 67.5  && angle <= 112.5){
			angle = 90;
		}
		//135 degree
		else if(angle > 112.5  && angle <= 157.5){
			angle = 135;
		}
		//180 degree
		//if(angle > 157.5  && angle <= -157.5){
			//angle = 90;
		//}
		//225 degree
		else if(angle > -157.5  && angle <= -112.5){
			angle = -135;
		}
		//270 degree
		else if(angle > -112.5  && angle <= -67.5){
			angle = -90;
		}
		//315 degree
		else if(angle > -67.5  && angle <= -22.5){
			angle = -45;
		}
		else{
			angle = 180;
		}
		*/
		


		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        player = PlayerState.player;
		
		//transform.rotation = direction;
		if(player == 1){
			//.3142Debug.Log("works");
			if(coolddownInc >= cooldownMax){
				if(Input.GetButton("P1fire1")){
					Instantiate(projectile1, projectileSpawn.position, projectileSpawn.rotation);
					coolddownInc = 0;

				}
				if(Input.GetButton("P1fire2")){
					Instantiate(projectile2, projectileSpawn.position, projectileSpawn.rotation);
					coolddownInc = 0;

				}
			}
		}else{
			Debug.Log("still not working");
		}
		
	}
	

}
