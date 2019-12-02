using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using UnityEngine.SceneManagement;

public class CharacterSelector : MonoBehaviour
{
    // Start is called before the first frame update

    private Player player1;
    private Player player2;

    [SerializeField] GameObject p1Selector;
    [SerializeField] GameObject p2Selector;

    [SerializeField] bool p1Confirm;
    [SerializeField] bool p2Confirm;


    [SerializeField] Transform chefSelect;
    [SerializeField] Transform spySelect;
    [SerializeField] Transform witchSelect;
    [SerializeField] Transform pirateSelect;


    void Start()
    {
        player1 = ReInput.players.GetPlayer(0);
        player2 = ReInput.players.GetPlayer(1);

       // p1Selector.transform.position = chefSelect.position;
       // p2Selector.transform.position = spySelect.position;

    }

    // Update is called once per frame
    void Update() // 0 = chef | 1 = spy | 2 = pirate | 3 = witch
    {
        if (player1.GetButton("SelectChef")) //0
        {
            p1Selector.transform.position = chefSelect.position;
            CharacterSelect.p1Character = 0;
            
            if(CharacterSelect.p2Character == 0)
            {
                CharacterSelect.p2Character = 4;
            }
        }
        if (player1.GetButton("SelectSpy")) //1
        {
            //p1Selector.transform.position = spySelect.position;
            //CharacterSelect.p1Character = 1;
            //if (CharacterSelect.p2Character == 1)
            //{
            //    CharacterSelect.p2Character = 5;
            //}

        }
        if (player1.GetButton("SelectPirate")) //2
        {
            p1Selector.transform.position = pirateSelect.position;
            CharacterSelect.p1Character = 2;

            if (CharacterSelect.p2Character == 2)
            {
                CharacterSelect.p2Character = 6;
            }

        }
        if (player1.GetButton("SelectWitch")) //3
        {
            p1Selector.transform.position = witchSelect.position;
            CharacterSelect.p1Character = 3;

            if (CharacterSelect.p2Character == 3)
            {
                CharacterSelect.p2Character = 7;
            }

        }
        if (player1.GetButton("ConfirmCharacter"))
        {
            p1Confirm = true;
        }

        if (player2.GetButton("SelectChef"))
        {
            if (CharacterSelect.p1Character == 0)
            {
                CharacterSelect.p2Character = 4;

            }
            else
            {
                p2Selector.transform.position = chefSelect.position;
                CharacterSelect.p2Character = 0;
            }
        }
        if (player2.GetButton("SelectSpy"))
        {
            if (CharacterSelect.p1Character == 1)
            {
                CharacterSelect.p2Character = 5;
            }
            else
            {
                p2Selector.transform.position = spySelect.position;
                CharacterSelect.p2Character = 1;
            }
        }
        if (player2.GetButton("SelectPirate"))
        {
            if (CharacterSelect.p1Character == 2)
            {
                CharacterSelect.p2Character = 6;
            }
            else
            {
                p2Selector.transform.position = pirateSelect.position;
                CharacterSelect.p2Character = 2;
            }
        }
        if (player2.GetButton("SelectWitch"))
        {
            if (CharacterSelect.p1Character == 3)
            {
                CharacterSelect.p2Character = 7;
            }
            else
            {
                p2Selector.transform.position = witchSelect.position;
                CharacterSelect.p2Character = 3;
            }
        }
        if (player2.GetButton("ConfirmCharacter"))
        {
            p2Confirm = true;
        }


        if(p1Confirm && p2Confirm)
        {
            SceneManager.LoadScene("Instructions");
        }

    }
}
