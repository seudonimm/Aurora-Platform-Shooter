using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VSSceneManager : MonoBehaviour
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
        if (CharacterSelect.p2Character == 0 || CharacterSelect.p2Character == 4)
        {
            Instantiate(chef, p2Spawner.position, p2Spawner.rotation);

        }
        else if (CharacterSelect.p2Character == 1 || CharacterSelect.p2Character == 5)
        {
            Instantiate(spy, p2Spawner.position, p2Spawner.rotation);

        }
        else if (CharacterSelect.p2Character == 2 || CharacterSelect.p2Character == 6)
        {
            Instantiate(pirate, p2Spawner.position, p2Spawner.rotation);

        }
        else if (CharacterSelect.p2Character == 3 || CharacterSelect.p2Character == 7)
        {
            Instantiate(witch, p2Spawner.position, p2Spawner.rotation);

        }

        Invoke("LoadBattleScene", 2.5f);

    }

    void LoadBattleScene()
    {
        if (CharacterSelect.stage == 0)
        {
            SceneManager.LoadScene("BattleScene01");
        }
        if (CharacterSelect.stage == 1)
        {
            SceneManager.LoadScene("BattleScene03");

        }
        if (CharacterSelect.stage == 2)
        {
            SceneManager.LoadScene("BattleScene02");
        }
        if (CharacterSelect.stage == 3)
        {
            SceneManager.LoadScene("BattleScene04");
        }

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
