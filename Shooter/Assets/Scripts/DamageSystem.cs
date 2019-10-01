using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
//	[SerializeField] float chargeVal = 10;
	//[SerializeField] float healthVal = 100;
	//[SerializeField] float defaultChargeVal;
	//[SerializeField] float defaultHealthVal;
	
	[SerializeField] GameObject p1;
	[SerializeField] GameObject p2;
	
	public PlayerHealth p1;
		
	static float player;

    static float player2;
    
	// Start is called before the first frame update
    void Start()
    {
        p1 = GameObject.FindGameObjectWithTag("Player 1").GetComponent&lt;PlayerHealth&gt;
		//p2 = GameObject.FindGameObjectsWithTag("Player 2");
		
    }

    // Update is called once per frame
    void Update()
    {
        player = PlayerState.player;

        player2 = PlayerState2.player;
    }
	
	void OnCollisionEnter2D(Collision2D col){
		if(player == 1){
			if(col.gameObject.CompareTag("Charge Shot")){
				p1.chargeVal -= 5;
				p2.chargeVal += 10;
			}
			if(col.gameObject.CompareTag("Damage Shot")){
				p1.healthVal -= p2.chargeVal;
			}
		}
		else if(player == 2){
			if(col.gameObject.CompareTag("Charge Shot")){
				p2.chargeVal -= 5;
				p1.chargeVal += 10;
			}
			if(col.gameObject.CompareTag("Damage Shot")){
				p2.healthVal -= p1.chargeVal;
			}
		}
	}
}
