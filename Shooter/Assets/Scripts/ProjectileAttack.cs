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

    [SerializeField] GameObject chef;
    [SerializeField] GameObject witch;
    [SerializeField] GameObject spy;
    [SerializeField] GameObject pirate;

    [SerializeField] GameObject chef2;
    [SerializeField] GameObject witch2;
    [SerializeField] GameObject spy2;
    [SerializeField] GameObject pirate2;


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


    void Start()
    {
        player1 = ReInput.players.GetPlayer(0);
        player2 = ReInput.players.GetPlayer(1);


        Invoke("AssignP1P2", .1f);

    }


    void AssignP1P2()
    {        
        self = this.transform.gameObject;

        if (CharacterSelect.p1Character == 0) // 0 = chef | 1 = spy | 2 = pirate | 3 = witch
        {
            p1 = chef.transform.GetChild(0).gameObject;
            if (p1 == self)
            {

                projectile1 = chefProjC1;
                projectile2 = chefProjH1;
            }
        }
        else if (CharacterSelect.p1Character == 1)
        {
            p1 = spy.transform.GetChild(0).gameObject;
            if (p1 == self)
            {
                projectile1 = spyProjC1;
                projectile2 = spyProjH1;
            }
        }
        else if (CharacterSelect.p1Character == 2)
        {
            p1 = pirate.transform.GetChild(0).gameObject;
            if (p1 == self)
            {
                projectile1 = pirateProjC1;
                projectile2 = pirateProjH1;
            }

        }
        else if (CharacterSelect.p1Character == 3)
        {
            p1 = witch.transform.GetChild(0).gameObject;
            if (p1 == self)
            {
                projectile1 = witchProjC1;
                projectile2 = witchProjH1;
            }

        }

        //P2 Character Select
        if (CharacterSelect.p2Character == 0)
        {
            p2 = chef.transform.GetChild(0).gameObject;
            if (p2 == self)
            {
                projectile1 = chefProjC2;
                projectile2 = chefProjH2;
            }

        }
        else if (CharacterSelect.p2Character == 1)
        {
            p2 = spy.transform.GetChild(0).gameObject;
            if (p2 == self)
            {
                projectile1 = spyProjC2;
                projectile2 = spyProjH2;
            }

        }
        else if (CharacterSelect.p2Character == 2)
        {
            p2 = pirate.transform.GetChild(0).gameObject;
            if (p2 == self)
            {
                projectile1 = pirateProjC2;
                projectile2 = pirateProjH2;
            }

        }
        else if (CharacterSelect.p2Character == 3)
        {
            p2 = witch.transform.GetChild(0).gameObject;
            if (p2 == self)
            {
                projectile1 = witchProjC2;
                projectile2 = witchProjH2;
            }

        }
        else if(CharacterSelect.p2Character == 4)
        {
            p2 = chef2.transform.GetChild(0).gameObject;
            if (p2 == self)
            {
                projectile1 = chefProjC2;
                projectile2 = chefProjH2;
            }

        }
        else if (CharacterSelect.p2Character == 5)
        {
            p2 = spy2.transform.GetChild(0).gameObject;
            if (p2 == self)
            {
                projectile1 = spyProjC2;
                projectile2 = spyProjH2;
            }

        }
        else if (CharacterSelect.p2Character == 6)
        {
            p2 = pirate2.transform.GetChild(0).gameObject;
            if (p2 == self)
            {
                projectile1 = pirateProjC2;
                projectile2 = pirateProjH2;
            }

        }
        else if (CharacterSelect.p2Character == 7)
        {
            p2 = witch2.transform.GetChild(0).gameObject;
            if (p2 == self)
            {
                projectile1 = witchProjC2;
                projectile2 = witchProjH2;
            }

        }

        if (self == p1)
        {
            p1.tag = "p1shooter";
        }
        else if (self == p2)
        {
            p2.tag = "p2shooter";
        }

    }






    void Fire()
    {
        if (p1 == self && this.gameObject.CompareTag("p1shooter"))
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
        if (p2 == self && this.gameObject.CompareTag("p2shooter"))
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