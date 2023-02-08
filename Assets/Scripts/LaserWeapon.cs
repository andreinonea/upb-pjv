using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserWeapon : Weapon
{
    [SerializeField]
    private new Camera camera;

    LineRenderer laserRenderer;
    bool ready = true;

    public float laserDuration = 0.1f;
    public float gunRange = 50f;
    public float fireRate = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        laserRenderer = GetComponent<LineRenderer>();
    }
 
    public override void Fire()
    {
        if (!ready)
            return;

        Debug.Log("Laser FIRE");

        Ray mouseClickRay = camera.ScreenPointToRay(Input.mousePosition); //creaza o raza printr-un punct de pe ecran
        RaycastHit hit;
        laserRenderer.SetPosition(0, transform.position);

        if (Physics.Raycast(mouseClickRay, out hit))
        {
            Debug.Log("hit something");
            laserRenderer.SetPosition(1, hit.point);

            EnemyController enemy = hit.transform.GetComponent<EnemyController>();
            if (enemy != null)
                enemy.Die();
        }
        else
        {
            laserRenderer.SetPosition(1, transform.position + (transform.forward * gunRange));
        }

        ready = false;
        StartCoroutine(DrawLaser());
        StartCoroutine(CoolDownLaser());
    }

    IEnumerator DrawLaser()
    {
        laserRenderer.enabled = true;
        yield return new WaitForSeconds(laserDuration);
        laserRenderer.enabled = false;
    }

    IEnumerator CoolDownLaser()
    {
        yield return new WaitForSeconds(fireRate);
        ready = true;
    }
}
