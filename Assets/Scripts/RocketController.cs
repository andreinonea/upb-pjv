using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    [SerializeField]
    private float fuse = 1.0f;

    [SerializeField]
    ParticleSystem explosionParticles;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!rb.isKinematic && gameObject != null)
            StartCoroutine(DestroyOnFuse());
    }

    IEnumerator DestroyOnFuse()
    {
        yield return new WaitForSeconds(fuse);
        Explode();
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("COLLIDED");
        Explode();
    }

    private void Explode()
    {
        Debug.Log(transform.position);
        ParticleSystem clone = Instantiate(explosionParticles, transform.position, Quaternion.identity);
        if (gameObject != null)
            Destroy(gameObject);
    }
}
