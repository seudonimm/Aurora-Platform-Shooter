using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem1 : MonoBehaviour
{
    public PlayerHealth p1;
    public PlayerHealth p2;

    static float player;

    static float player2;

    // Start is called before the first frame update
    void Start()
    {
        p1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerHealth>();
        p2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerHealth>();

    }

    // Update is called once per frame
    void Update()
    {
        player = PlayerState.player;

        player2 = PlayerState2.player;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (player == 1)
        {
            //Debug.Log("p1 hit");
            if (col.gameObject.CompareTag("Charge Shot"))
            {
                Debug.Log("1 with charge");
                p1.chargeVal -= 10;
                p2.chargeVal += 10;
            }
            if (col.gameObject.CompareTag("Damage Shot"))
            {
                p1.healthVal -= p2.chargeVal;
                p2.chargeVal = p2.defaultChargeVal;
            }
        }

        if (player2 == 2)
        {
            Debug.Log("p2 hit");
            if (col.gameObject.CompareTag("Charge Shot"))
            {
                Debug.Log("2 with charge");
                p2.chargeVal -= 10;
                p1.chargeVal += 10;
            }
            if (col.gameObject.CompareTag("Damage Shot"))
            {
                p2.healthVal -= p1.chargeVal;
                p1.chargeVal = p1.defaultChargeVal;

            }
        }
    }
}
