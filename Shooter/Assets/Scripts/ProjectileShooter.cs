using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    [SerializeField] GameObject projectile1;
    [SerializeField] GameObject projectile2;
    [SerializeField] Transform projectileSpawn;


    [SerializeField] float cooldownMax;
    [SerializeField] float cooldownInc;

    Vector2 direction;

    private Controls controls = null;

    public Vector2 aimVector;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        controls = new Controls();
    }
    // Update is called once per frame
    void Update()
    {
        GetInput();
        ProcessInput();

        Fire();

        cooldownInc++;

    }

    private void OnEnable()
    {
        controls.Player.Enable();
    }
    private void OnDisable()
    {
        controls.Player.Disable();
    }




    void GetInput()
    {
        var movementInput = controls.Player.Aim.ReadValue<Vector2>();
        aimVector = movementInput;
    }
    void ProcessInput()
    {
        float joyAngle = Mathf.Atan2(aimVector.y, aimVector.x) * Mathf.Rad2Deg;
        projectileSpawn.rotation = Quaternion.AngleAxis(joyAngle, Vector3.forward);

    }

    void Fire()
    {

        if (cooldownInc >= cooldownMax)
        {
            
            if (controls.Player.ChargeShot.ReadValue<float>() != 0)
            {
                Instantiate(projectile1, projectileSpawn.position, projectileSpawn.rotation);
                cooldownInc = 0;

                Debug.Log("charge shot");

            }
            if (controls.Player.HPShot.ReadValue<float>() != 0)
            {
                Instantiate(projectile2, projectileSpawn.position, projectileSpawn.rotation);
                cooldownInc = 0;

                Debug.Log("hp shot");

            }
        }

    }


}
