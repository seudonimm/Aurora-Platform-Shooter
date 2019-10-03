using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileActions : MonoBehaviour
{
	[SerializeField] float damageValue = 20f;
	

	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
		void OnCollisionEnter2D(Collision2D col)
    {
		//Debug.Log("Player hit");
        if (col.gameObject.CompareTag("Player2"))
        {
			//Debug.Log("destroy projectile");
			
            Destroy(this.gameObject);
        }

    }
}
