using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
public class ProjectileAttack2 : MonoBehaviour
{
    // Use this for initialization
    [SerializeField] float speed;

	[SerializeField] GameObject projectile1;
	[SerializeField] GameObject projectile2;
    [SerializeField] Transform projectileSpawn2;

    [SerializeField] Rigidbody2D rb;

    string fire = null;


    Vector2 direction;
	
	[SerializeField] float cooldownMax;
	[SerializeField] float coolddownInc;

    private Player player2;
    Vector3 aimVector;
	
    void Start()
    {
        player2 = ReInput.players.GetPlayer(1);


    }


    void Fire()
    {

        if (coolddownInc >= cooldownMax)
        {
            if (player2.GetButton("Charge Shot"))
            {
                Instantiate(projectile1, projectileSpawn2.position, projectileSpawn2.rotation);
                coolddownInc = 0;

            }
            if (player2.GetButton("HP Shot"))
            {
                Instantiate(projectile2, projectileSpawn2.position, projectileSpawn2.rotation);
                coolddownInc = 0;
            }
        }

    }
    void GetInput()
    {
        aimVector.x = player2.GetAxis("Aim Horizontal");

        aimVector.y = player2.GetAxis("Aim Vertical");

    }
    void ProcessInput()
    {
        float joyAngle = Mathf.Atan2(aimVector.y, aimVector.x) * Mathf.Rad2Deg;
        projectileSpawn2.rotation = Quaternion.AngleAxis(joyAngle, Vector3.forward);


    }



    // Update is called once per frame
    void Update()
    {
        Fire();
        GetInput();
        ProcessInput();


        coolddownInc++;
    }
	

}
