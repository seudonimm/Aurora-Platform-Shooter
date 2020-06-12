using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using UnityEngine.SceneManagement;

public class InstructionsSceneManager : MonoBehaviour
{
    private Player player1;
    private Player player2;

    [SerializeField] bool p1Confirm;
    [SerializeField] bool p2Confirm;

    // Start is called before the first frame update
    void Start()
    {
        player1 = ReInput.players.GetPlayer(0);
        player2 = ReInput.players.GetPlayer(1);

        p1Confirm = false;
        p2Confirm = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (player1.GetButton("Start"))
        {
            p1Confirm = true;
        }
        if (player2.GetButton("Start"))
        {
            p2Confirm = true;
        }

        if (p1Confirm && p2Confirm)
        {
            SceneManager.LoadScene("StageSelect");
        }
    }
}
