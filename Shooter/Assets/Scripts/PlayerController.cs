using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float jumpHeight = 1000f;
    [SerializeField] Rigidbody2D rb;


    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Jump()
    {
        transform.position = new Vector2(
            transform.position.x,
            transform.position.y + jumpHeight);

        Debug.Log("new jump");

    }
}
