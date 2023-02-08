using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGWeapon : Weapon
{
    [SerializeField]
    private new Camera camera;

    [SerializeField]
    private GameObject projectile;
    private GameObject loaded = null;

    [SerializeField]
    private float fireRate = 1.0f;

    private void Start()
    {
        loaded = Instantiate(projectile, transform);
    }

    public override void Fire()
    {
        if (loaded == null)
            return;

        Debug.Log("RPG FIRE");

        loaded.transform.SetParent(null);
        Rigidbody rb = loaded.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.AddForce(transform.forward * 1000.0f);

        loaded = null;
        StartCoroutine(LoadRocket());
    }

    IEnumerator LoadRocket()
    {
        yield return new WaitForSeconds(fireRate);
        loaded = Instantiate(projectile, transform);
    }
}
