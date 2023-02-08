using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject primaryAttack;
    private Weapon primaryWeapon;

    [SerializeField]
    private GameObject secondaryAttack;
    private Weapon secondaryWeapon;

    // Start is called before the first frame update
    void Start()
    {
        primaryWeapon = primaryAttack.GetComponent<Weapon>();
        secondaryWeapon = secondaryAttack.GetComponent<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            primaryWeapon.Fire();
        }
        if (Input.GetMouseButtonDown(1))
        {
            secondaryWeapon.Fire();
        }
    }
}
