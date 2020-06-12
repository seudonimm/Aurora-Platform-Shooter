using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] float cooldownMax;
    [SerializeField] float cooldownInc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cooldownInc++;
        if(cooldownInc == cooldownMax)
        {
            Destroy(gameObject);
        }
    }
}
