using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryingPan : MonoBehaviour
{
    [SerializeField] float projSpeed;



    float bounce = 0;


    Rigidbody2D rb;





    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * projSpeed;

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        bounce++;

        if (bounce >= 3)
        {
            Destroy(this.gameObject);
        }

        if (col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("Player1") || col.gameObject.CompareTag("Player2"))
        {
            Destroy(this.gameObject);
        }

    }


}
