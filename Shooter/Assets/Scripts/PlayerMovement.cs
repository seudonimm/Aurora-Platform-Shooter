using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 25;
    [SerializeField] float jump = 15;
	
    [SerializeField] Rigidbody2D rb1;
	[SerializeField] Rigidbody2D rb2;
	
	[SerializeField] bool faceRight;

    [SerializeField] GameObject p1;
    [SerializeField] GameObject p2;

    [SerializeField] bool onGround;
		
	[SerializeField] float dodgeCooldownMax = 100;
	[SerializeField] float dodgeCooldownInc = 0;

    //static float player;

    //static float player2;
	
	private Player player1;
	private Player player2;
	private Vector3 moveVector;
	[SerializeField] Vector3 moveVector2;

    [SerializeField] int character; // 0 = chef | 1 = spy | 2 = pirate | 3 = witch

    //character prefabs
    [SerializeField] GameObject chef;
    [SerializeField] GameObject witch;
    [SerializeField] GameObject spy;
    [SerializeField] GameObject pirate;

    [SerializeField] GameObject chef2;
    [SerializeField] GameObject witch2;
    [SerializeField] GameObject spy2;
    [SerializeField] GameObject pirate2;

    [SerializeField] GameObject self;

    [SerializeField] float explosionSpeed;
    [SerializeField] Transform explosionSpawn;
    [SerializeField] GameObject explosion;

    [SerializeField] bool moveWitch = false;
    [SerializeField] float flyCooldownMax;
    [SerializeField] float flyCooldownInc;
    [SerializeField] float currentGravity;

    [SerializeField] float slideSpeed = 1000;

    [SerializeField] float moveSpecialCooldownInc;
    [SerializeField] float moveSpecialCooldownMax;

    public PlayerHealth ph1;
    public PlayerHealth ph2;

    SpriteRenderer sr;

    public int p1Num;
    public int p2Num;
    


    //[SerializeField] public float chargeVal = 10;
    //[SerializeField] public float healthVal = 1000;
    //[SerializeField] public float defaultChargeVal = 10;
    //[SerializeField] public float defaultHealthVal = 1000;

    //[SerializeField] public TextMesh p1Charge;
    //[SerializeField] TextMesh p1Health;
    //[SerializeField] TextMesh p2Charge;
    //[SerializeField] TextMesh p2Health;




    // Start is called before the first frame update
    void Start()
    {
		player1 = ReInput.players.GetPlayer(0);
		player2 = ReInput.players.GetPlayer(1);
			
        //rb = GetComponent<Rigidbody2D>();
		faceRight = true;

        //P1 Character Select
        if (CharacterSelect.p1Character == 0)
        {
            p1 = chef;
            rb1 = chef.GetComponent<Rigidbody2D>();
        }
        else if (CharacterSelect.p1Character == 1)
        {
            p1 = spy;
            rb1 = spy.GetComponent<Rigidbody2D>();

        }
        else if (CharacterSelect.p1Character == 2)
        {
            p1 = pirate;
            rb1 = pirate.GetComponent<Rigidbody2D>();

        }
        else if (CharacterSelect.p1Character == 3)
        {
            p1 = witch;
            rb1 = witch.GetComponent<Rigidbody2D>();

        }

        //P2 Character Select
        if (CharacterSelect.p2Character == 0)
        {
            p2 = chef;
            rb2 = chef.GetComponent<Rigidbody2D>();

        }
        else if (CharacterSelect.p2Character == 1)
        {
            p2 = spy;
            rb2 = spy.GetComponent<Rigidbody2D>();

        }
        else if (CharacterSelect.p2Character == 2)
        {
            p2 = pirate;
            rb2 = pirate.GetComponent<Rigidbody2D>();

        }
        else if (CharacterSelect.p2Character == 3)
        {
            p2 = witch;
            rb2 = witch.GetComponent<Rigidbody2D>();

        }
        else if (CharacterSelect.p2Character == 4)
        {
            p2 = chef2;
            rb2 = chef2.GetComponent<Rigidbody2D>();

        }
        else if (CharacterSelect.p2Character == 5)
        {
            p2 = spy2;
            rb2 = spy2.GetComponent<Rigidbody2D>();

        }
        else if (CharacterSelect.p2Character == 6)
        {
            p2 = pirate2;
            rb2 = pirate2.GetComponent<Rigidbody2D>();

        }
        else if (CharacterSelect.p2Character == 7)
        {
            p2 = witch2;
            rb2 = witch2.GetComponent<Rigidbody2D>();

        }

        self = this.gameObject;
        if(self == p1)
        {
            p1.tag = "Player1";
            p1.layer = 8;
        }
        else if (self == p2)
        {
            p2.tag = "Player2";
            p2.layer = 9;
        }

        currentGravity = rb1.gravityScale;

        Invoke("Assign", 0.1f);

        sr = this.GetComponent<SpriteRenderer>();


        //p1Charge = GameObject.FindGameObjectWithTag("p1charge").GetComponent<TextMesh>();
        //p1Health = GameObject.FindGameObjectWithTag("p1hp").GetComponent<TextMesh>();
        //p2Charge = GameObject.FindGameObjectWithTag("p2charge").GetComponent<TextMesh>();
        //p2Health = GameObject.FindGameObjectWithTag("p2hp").GetComponent<TextMesh>();

        p1Num = CharacterSelect.p1Character;
        p2Num = CharacterSelect.p2Character;
    }

    void Assign()
    {
        ph1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerHealth>();
        ph2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerHealth>();

    }

    void GetInput(){
		moveVector.x = player1.GetAxis("Move Horizontal");	
		
		moveVector2.x = player2.GetAxis("Move Horizontal");

        moveVector.y = player1.GetAxis("Move Vertical");

        moveVector2.y = player2.GetAxis("Move Vertical");


    }




    void ProcessInput2(){
		if(moveVector2.x > 0){
			p2.transform.position += transform.right * moveSpeed * Time.deltaTime;
		}
		if(moveVector2.x < 0){
			p2.transform.position += -transform.right * moveSpeed * Time.deltaTime;
		}
        if (moveWitch)
        {
            if (moveVector2.y > 0)
            {
                p2.transform.position += transform.up * moveSpeed * Time.deltaTime;
            }
            if (moveVector2.y < 0)
            {
                p2.transform.position += -transform.up * moveSpeed * Time.deltaTime;
            }
        }

        if (player2.GetButtonDown("Jump") && onGround == true)
        {
            if (!moveWitch)
            {
                rb2.AddForce(Vector2.up * jump);
            }
        }

        if (player2.GetButtonDown("Dodge"))
        {
            //p1Collider.enabled = false;

            Physics2D.IgnoreLayerCollision(8, 11, true);

            Debug.Log("Dodging");

            if (dodgeCooldownInc > dodgeCooldownMax)
            {
                //p1Collider.enabled = false;

                Debug.Log(dodgeCooldownInc);
                Debug.Log(dodgeCooldownMax);

                Physics2D.IgnoreLayerCollision(8, 11, false);

                dodgeCooldownInc = 0;
            }
        }
    }


    void ProcessInput(){
		if(moveVector.x > 0){
			p1.transform.position += transform.right * moveSpeed * Time.deltaTime;
		}
		if(moveVector.x < 0){
			p1.transform.position += -transform.right * moveSpeed * Time.deltaTime;
		}

        if (moveWitch)
        {
            if (moveVector.y > 0)
            {
                p1.transform.position += transform.up * moveSpeed * Time.deltaTime;
            }
            if (moveVector.y < 0)
            {
                p1.transform.position += -transform.up * moveSpeed * Time.deltaTime;
            }
        }

        if (player1.GetButtonDown("Jump") && onGround == true) {
            if (!moveWitch) {
                rb1.AddForce(Vector2.up * jump);
            }
        }

        if (player1.GetButtonDown("Dodge"))
        {
            //p1Collider.enabled = false;

            Physics2D.IgnoreLayerCollision(8, 11, true);

            Debug.Log("Dodging");
        }

        if (dodgeCooldownInc > dodgeCooldownMax)
        {
            //p1Collider.enabled = false;

            //Debug.Log(dodgeCooldownInc);
            //Debug.Log(dodgeCooldownMax);

            Physics2D.IgnoreLayerCollision(8, 11, false);

            dodgeCooldownInc = 0;
        }


    }

    void ToCharacterSelect()
    {
        SceneManager.LoadScene("CharacterSelect");
    }

    // Update is called once per frame
    void Update()
    {
		GetInput();
		ProcessInput();
		ProcessInput2();

        dodgeCooldownInc++;

        moveSpecialCooldownInc++;


        if (player1.GetButton("Movement Ability") && moveSpecialCooldownInc >= moveSpecialCooldownMax)
        {
            if (p1 == chef)
            {
                ChefSpecial();
            }
            else if (p1 == witch)
            {
                WitchSpecial();
            }
            else if (p1 == pirate)
            {
                PirateSpecial();
            }
            else if (p1 == spy)
            {
                SpySpecial();
            }
            moveSpecialCooldownInc = 0;

        }
        if (player2.GetButton("Movement Ability") && moveSpecialCooldownInc >= moveSpecialCooldownMax)
        {
            if (p2 == chef)
            {
                ChefSpecial();
            }
            else if (p2 == witch)
            {
                WitchSpecial2();
            }
            else if (p2 == pirate)
            {
                PirateSpecial2();
            }
            else if (p2 == spy)
            {
                SpySpecial();
            }
            else if (p2 == chef2)
            {
                ChefSpecial2();
            }
            else if (p2 == witch2)
            {
                WitchSpecial2();
            }
            else if (p2 == pirate2)
            {
                PirateSpecial2();
            }
            else if (p2 == spy2)
            {
                SpySpecial2();
            }
            moveSpecialCooldownInc = 0;

        }



        flyCooldownInc++;

        if (flyCooldownInc >= flyCooldownMax)
        {
            moveWitch = false;
            rb1.gravityScale = currentGravity;
            rb2.gravityScale = currentGravity;
        }

        Invoke("Invoker", 1f);

    }

    void Invoker()
    {
        if (ph1.healthVal <= 0 || ph2.healthVal <= 0)
                {
                    Invoke("ToCharacterSelect", 6f);
                }
    }

    public void ChefSpecial()
    {
        
        if (self == p1)
        {
            if (moveVector.x > 0)
            {
                rb1.AddForce(Vector2.right * slideSpeed);
            }
            if (moveVector.x < 0)
            {
                rb1.AddForce(-Vector2.right * slideSpeed);
            }
        }

        Debug.Log("slide");
    }

    public void WitchSpecial()
    {
        if (self == p1)
        {
            moveWitch = true;

            rb1.gravityScale = 0;

            flyCooldownInc = 0;
            Debug.Log("1");

        }
    }

    public void PirateSpecial()
    {
        Instantiate(explosion, explosionSpawn.position, explosionSpawn.rotation);

        if (self == p1)
        {
            rb1.AddForce(moveVector * explosionSpeed);
        }
        if (self == p2)
        {
            rb2.AddForce(moveVector2 * explosionSpeed);
        }
    }

    public void SpySpecial()
    {

    }


    public void ChefSpecial2()
    {

        if (self == p2)
        {
            if (moveVector2.x > 0)
            {
                rb2.AddForce(Vector2.right * slideSpeed);
            }
            if (moveVector2.x < 0)
            {
                rb2.AddForce(-Vector2.right * slideSpeed);
            }
        }

        Debug.Log("slide");
    }

    public void WitchSpecial2()
    {

        if (self == p2)
        {
            moveWitch = true;

            rb2.gravityScale = 0;

            flyCooldownInc = 0;
            Debug.Log("3");
        }
    }

    public void PirateSpecial2()
    {
        Instantiate(explosion, explosionSpawn.position, explosionSpawn.rotation);


        if (self == p2)
        {
            rb2.AddForce(moveVector2 * explosionSpeed);
        }
    }

    public void SpySpecial2()
    {

    }

    //public void PlayerHealth()
    //{
    //    if (self == p1)
    //    {
    //        p1Charge.text = "Charge: " + chargeVal;
    //        p1Health.text = "Health: " + healthVal;
    //    }
    //    else if (self == p2)
    //    {
    //        p2Charge.text = "Charge: " + chargeVal;
    //        p2Health.text = "Health: " + healthVal;

    //    }
    //    if (chargeVal < 0)
    //    {
    //        chargeVal = 5;
    //    }

    //    if (healthVal <= 0)
    //    {
    //        Destroy(gameObject);
    //    }
    //}


    void HitColor()
    {
        sr.color = Color.red;

    }
    void AfterHitColor()
    {
        sr.color = Color.white;




    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }



        if (self == p1)
        {

            //Debug.Log("p1 hit");
            if (col.gameObject.CompareTag("Charge Shot"))
            {
                HitColor();
                Invoke("AfterHitColor", .3f);

                Debug.Log("1 with charge");
                ph1.chargeVal -= 10;
                ph2.chargeVal += 10;
            }
            if (col.gameObject.CompareTag("Damage Shot"))
            {
                HitColor();
                Invoke("AfterHitColor", .3f);

                ph1.healthVal -= ph2.chargeVal;
                ph2.chargeVal = ph2.defaultChargeVal;
            }
        }

        if (self == p2)
        {

            Debug.Log("p2 hit");
            if (col.gameObject.CompareTag("Charge Shot"))
            {
                HitColor();
                Invoke("AfterHitColor", .3f);

                Debug.Log("2 with charge");
                ph2.chargeVal -= 10;
                ph1.chargeVal += 10;
            }
            if (col.gameObject.CompareTag("Damage Shot"))
            {
                HitColor();
                Invoke("AfterHitColor", .3f);

                ph2.healthVal -= ph1.chargeVal;
                ph1.chargeVal = ph1.defaultChargeVal;

            }
        }
    }



    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            onGround = false;
        }

    }

}

