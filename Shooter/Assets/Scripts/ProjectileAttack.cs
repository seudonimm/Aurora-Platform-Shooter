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


    [SerializeField] float cooldownMax;
    [SerializeField] float coolddownInc;

    string fire = null;
    static float player;

    Vector2 direction;

    private Player player1;
    private Player player2;

    public Vector2 aimVector;
    public Vector2 aimVector2;

    [SerializeField] GameObject p1;
    [SerializeField] GameObject p2;

    void Start() {
        player1 = ReInput.players.GetPlayer(0);
        player2 = ReInput.players.GetPlayer(1);

        
    }


    void Fire() {

        if (coolddownInc >= cooldownMax) {
            if (player1.GetButton("Charge Shot")) {
                Instantiate(projectile1, projectileSpawn.position, projectileSpawn.rotation);
                coolddownInc = 0;

            }
            if (player1.GetButton("HP Shot")) {
                Instantiate(projectile2, projectileSpawn.position, projectileSpawn.rotation);
                coolddownInc = 0;
            }
        }

    }


    // Update is called once per frame
    void Update() {
        Fire();
        GetInput();
        ProcessInput();
        ProcessInput2();

        coolddownInc++;

    }

    void GetInput()
    {
        aimVector.x = player1.GetAxis("Aim Horizontal");

        aimVector.y = player1.GetAxis("Aim Vertical");

        aimVector2.x = player2.GetAxis("Aim Horizontal");

        aimVector2.y = player2.GetAxis("Aim Vertical");

    }
    void ProcessInput()
    {
        float joyAngle = Mathf.Atan2(aimVector.y, aimVector.x) * Mathf.Rad2Deg;
        p1.transform.rotation = Quaternion.AngleAxis(joyAngle, Vector3.forward);


    }
    void ProcessInput2()
    {
        float joyAngle = Mathf.Atan2(aimVector2.y, aimVector2.x) * Mathf.Rad2Deg;
        p2.transform.rotation = Quaternion.AngleAxis(joyAngle, Vector3.forward);


    }
}