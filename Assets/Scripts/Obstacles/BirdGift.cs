using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdGift : MonoBehaviour
{
    [SerializeField] private float despawnTime;
    [SerializeField] private ParticleSystem shartBuster;
    [SerializeField] private GameObject splatter;
    private float despawnTimer;
    
    void Start()
    {
        despawnTimer = 0;
        splatter.SetActive(false);
    }

    void Update()
    {
        despawnTimer += 1 * Time.deltaTime;
        if (despawnTimer > despawnTime)
            StartCoroutine(Explode());
    }

    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(Explode());
    }

    private IEnumerator Explode()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        shartBuster.Play();
        splatter.SetActive(true);
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {

        Gizmos.DrawWireSphere(gameObject.transform.position, 2);
        
    }
}
