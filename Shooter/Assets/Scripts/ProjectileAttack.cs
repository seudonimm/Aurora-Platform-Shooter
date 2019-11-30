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
    [SerializeField] Transform projectileSpawn2;


    [SerializeField] float cooldownMax;
    [SerializeField] float coolddownInc;

    [SerializeField] float cooldownMax2;
    [SerializeField] float coolddownInc2;

    string fire = null;
    static float player;

    Vector2 direction;

    private Player player1;
    private Player player2;

    public Vector2 aimVector;
    public Vector2 aimVector2;

    [SerializeField] GameObject p1;
    [SerializeField] GameObject p2;
    [SerializeField] GameObject self;

    [SerializeField] GameObject chefP1;
    [SerializeField] GameObject witchP1;
    [SerializeField] GameObject spyP1;
    [SerializeField] GameObject pirateP1;

    [SerializeField] GameObject chefP2;
    [SerializeField] GameObject witchP2;
    [SerializeField] GameObject spyP2;
    [SerializeField] GameObject pirateP2;



    [SerializeField] GameObject chefProjC1;
    [SerializeField] GameObject witchProjC1;
    [SerializeField] GameObject spyProjC1;
    [SerializeField] GameObject pirateProjC1;

    [SerializeField] GameObject chefProjC2;
    [SerializeField] GameObject witchProjC2;
    [SerializeField] GameObject spyProjC2;
    [SerializeField] GameObject pirateProjC2;

    [SerializeField] GameObject chefProjH1;
    [SerializeField] GameObject witchProjH1;
    [SerializeField] GameObject spyProjH1;
    [SerializeField] GameObject pirateProjH1;

    [SerializeField] GameObject chefProjH2;
    [SerializeField] GameObject witchProjH2;
    [SerializeField] GameObject spyProjH2;
    [SerializeField] GameObject pirateProjH2;


    void Start() {
        player1 = ReInput.players.GetPlayer(0);
        player2 = ReInput.players.GetPlayer(1);

        self = transform.gameObject;



        if (CharacterSelect.p1Character == 0) // 0 = chef | 1 = spy | 2 = pirate | 3 = witch
        {
            p1 = chefP1.transform.GetChild(0).gameObject;
            if(p1 == self)
            {
                projectile1 = chefProjC1;
                projectile2 = chefProjH1;
            }
        }
        else if (CharacterSelect.p1Character == 1)
        {
            p1 = spyP1.transform.GetChild(0).gameObject;
            if (p1 == self)
            {
                projectile1 = spyProjC1;
                projectile2 = spyProjH1;
            }
        }
        else if (CharacterSelect.p1Character == 2)
        {
            p1 = pirateP1.transform.GetChild(0).gameObject;
            if (p1 == self)
            {
                projectile1 = pirateProjC1;
                projectile2 = pirateProjH1;
            }

        }
        else if (CharacterSelect.p1Character == 3)
        {
            p1 = witchP1.transform.GetChild(0).gameObject;
            if (p1 == self)
            {
                projectile1 = witchProjC1;
                projectile2 = witchProjH1;
            }

        }

        //P2 Character Select
        if (CharacterSelect.p2Character == 0)
        {
            p2 = chefP2.transform.GetChild(0).gameObject;
            if (p2 == self)
            {
                projectile1 = chefProjC2;
                projectile2 = chefProjH2;
            }

        }
        else if (CharacterSelect.p2Character == 1)
        {
            p2 = spyP2.transform.GetChild(0).gameObject;
            if (p2 == self)
            {
                projectile1 = spyProjC2;
                projectile2 = spyProjH2;
            }

        }
        else if (CharacterSelect.p2Character == 2)
        {
            p2 = pirateP2.transform.GetChild(0).gameObject;
            if (p2 == self)
            {
                projectile1 = pirateProjC2;
                projectile2 = pirateProjH2;
            }

        }
        else if (CharacterSelect.p2Character == 3)
        {
            p2 = witchP2.transform.GetChild(0).gameObject;
            if (p2 == self)
            {
                projectile1 = witchProjC2;
                projectile2 = witchProjH2;
            }

        }

    }






    void Fire()
    {
        if (p1 == self)
        {
            if (coolddownInc >= cooldownMax)
            {
                if (player1.GetButton("Charge Shot"))
                {
                    Instantiate(projectile1, projectileSpawn.position, projectileSpawn.rotation);
                    coolddownInc = 0;

                }              
            }
            if (coolddownInc2 >= cooldownMax2)
            {
                if (player1.GetButton("HP Shot"))
                {
                    Instantiate(projectile2, projectileSpawn.position, projectileSpawn.rotation);
                    coolddownInc2 = 0;
                }
            }
        }
    }

    void Fire2()
    {
        if (p2 == self)
        {
            if (coolddownInc >= cooldownMax)
            {
                if (player2.GetButton("Charge Shot"))
                {
                    Instantiate(projectile1, projectileSpawn.position, projectileSpawn.rotation);
                    coolddownInc = 0;

                }
            }
            if (coolddownInc2 >= cooldownMax2)
            {
                if (player2.GetButton("HP Shot"))
                {
                    Instantiate(projectile2, projectileSpawn.position, projectileSpawn.rotation);
                    coolddownInc2 = 0;
                }
            }
        }
    }



    // Update is called once per frame
    void Update() {
        Fire();
        Fire2();
        GetInput();
        ProcessInput();
        ProcessInput2();

        coolddownInc++;
        coolddownInc2++;


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