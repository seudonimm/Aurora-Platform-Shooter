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

    private Player player1;
    public Vector2 aimVector;


    void Start() {
        player1 = ReInput.players.GetPlayer(0);

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

        coolddownInc++;

    }

    void GetInput()
    {
        aimVector.x = player1.GetAxis("Aim Horizontal");

        aimVector.y = player1.GetAxis("Aim Vertical");

    }
    void ProcessInput()
    {
        float joyAngle = Mathf.Atan2(aimVector.y, aimVector.x) * Mathf.Rad2Deg;
        projectileSpawn.rotation = Quaternion.AngleAxis(joyAngle, Vector3.forward);


    }
}