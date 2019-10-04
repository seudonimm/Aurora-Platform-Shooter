using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState2 : MonoBehaviour
{
    public static float player = 0;
    [SerializeField] float playerNum;
    // Start is called before the first frame update
    void Start()
    {
        /*if (gameObject.CompareTag("Player1"))
        {
            player = 1;
        }
        else*/
        if (gameObject.CompareTag("Player2"))
        {
            player = 2;
        }
        playerNum = player;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
