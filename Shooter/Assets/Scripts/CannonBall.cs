using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [SerializeField] float projSpeed;

    [SerializeField] Transform explosionSpawn;
    [SerializeField] GameObject explosion;




    public float durability = 0;


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

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Projectile"))
        {
            durability++;
        }

        if (durability >= 2 || col.gameObject.CompareTag("Wall") || col.gameObject.CompareTag("Ground") || col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("Player1") || col.gameObject.CompareTag("Player2"))
        {
            Destroy(this.gameObject);
            Instantiate(explosion, explosionSpawn.position, explosionSpawn.rotation);
        }




    }

}
