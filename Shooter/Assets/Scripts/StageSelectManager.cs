using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using UnityEngine.SceneManagement;

public class StageSelectManager : MonoBehaviour
{
    private Player player1;

    [SerializeField] GameObject p1Selector;

    [SerializeField] bool p1Confirm;

    [SerializeField] Transform chefSelect;
    [SerializeField] Transform spySelect;
    [SerializeField] Transform witchSelect;
    [SerializeField] Transform pirateSelect;


    // Start is called before the first frame update
    void Start()
    {
        player1 = ReInput.players.GetPlayer(0);

    }

    // Update is called once per frame
    void Update()
    {
        if (player1.GetButton("SelectChef")) //0
        {
            p1Selector.transform.position = chefSelect.position;
            CharacterSelect.stage = 0;
        }
        if (player1.GetButton("SelectSpy")) //1
        {
            p1Selector.transform.position = spySelect.position;
            CharacterSelect.stage = 1;

        }
        if (player1.GetButton("SelectPirate")) //2
        {
            p1Selector.transform.position = pirateSelect.position;
            CharacterSelect.stage = 2;

        }
        if (player1.GetButton("SelectWitch")) //3
        {
            p1Selector.transform.position = witchSelect.position;
            CharacterSelect.stage = 3;

        }
        if (player1.GetButton("ConfirmCharacter"))
        {
            p1Confirm = true;
        }

        if (p1Confirm)
        {
            SceneManager.LoadScene("VS Screen");
        }
    }
}
