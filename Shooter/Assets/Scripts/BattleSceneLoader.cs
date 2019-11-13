using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSceneLoader : MonoBehaviour
{
    [SerializeField] GameObject chef;
    [SerializeField] GameObject witch;
    [SerializeField] GameObject spy;
    [SerializeField] GameObject pirate;

    [SerializeField] Transform p1Spawner;
    [SerializeField] Transform p2Spawner;


    // Start is called before the first frame update
    void Start()
    {
        // 0 = chef | 1 = spy | 2 = pirate | 3 = witch

        //P1 Character Select
        if (CharacterSelect.p1Character == 0)
        {
            Instantiate(chef, p1Spawner.position, p1Spawner.rotation);
        }
        else if (CharacterSelect.p1Character == 1)
        {
            Instantiate(spy, p1Spawner.position, p1Spawner.rotation);
        }
        else if (CharacterSelect.p1Character == 2)
        {
            Instantiate(pirate, p1Spawner.position, p1Spawner.rotation);
        }
        else if (CharacterSelect.p1Character == 3)
        {
            Instantiate(witch, p1Spawner.position, p1Spawner.rotation);
        }

        //P2 Character Select
        if (CharacterSelect.p2Character == 0)
        {
            Instantiate(chef, p2Spawner.position, p2Spawner.rotation);

        }
        else if (CharacterSelect.p2Character == 1)
        {
            Instantiate(spy, p2Spawner.position, p2Spawner.rotation);

        }
        else if (CharacterSelect.p2Character == 2)
        {
            Instantiate(pirate, p2Spawner.position, p2Spawner.rotation);

        }
        else if (CharacterSelect.p2Character == 3)
        {
            Instantiate(witch, p2Spawner.position, p2Spawner.rotation);

        }

        //Stage Select
        if (CharacterSelect.stage == 0)
        {

        }
        else if (CharacterSelect.stage == 1)
        {

        }
        else if (CharacterSelect.stage == 2)
        {

        }
        else if (CharacterSelect.stage == 3)
        {

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
