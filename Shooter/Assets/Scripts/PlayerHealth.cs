using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
	[SerializeField] public float chargeVal = 10;
	[SerializeField] public float healthVal = 1000;
	[SerializeField] public float defaultChargeVal = 10;
	[SerializeField] public float defaultHealthVal = 1000;

    [SerializeField] TextMesh charge;
    [SerializeField] TextMesh health;

    [SerializeField] GameObject thisPlayer;



    // Start is called before the first frame update
    void Start()
    {


        thisPlayer = this.gameObject;

        Invoke("Assign", 0.2f);
        

    }

    void Assign()
    {
        if (thisPlayer.CompareTag("Player1"))
        {
            charge = GameObject.FindGameObjectWithTag("p1charge").GetComponent<TextMesh>();
            health = GameObject.FindGameObjectWithTag("p1hp").GetComponent<TextMesh>();
        }
        if (thisPlayer.CompareTag("Player2"))
        {
            charge = GameObject.FindGameObjectWithTag("p2charge").GetComponent<TextMesh>();
            health = GameObject.FindGameObjectWithTag("p2hp").GetComponent<TextMesh>();
        }
        charge.text = "Charge: " + chargeVal;
        health.text = "Health: " + healthVal;

    }
    // Update is called once per frame
    void Update()
    {

        charge.text = "Charge: " + chargeVal;
        health.text = "Health: " + healthVal;

        if(chargeVal < 0)
        {
            chargeVal = 5;
        }

        if(healthVal <= 0)
        {
            Destroy(gameObject);
        }
    }
}
