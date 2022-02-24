using System.Collections;
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

    // Counts up the despawner timer and starts the exlposion coroutine when despawntimer reaches a certain time
    void Update()
    {
        despawnTimer += 1 * Time.deltaTime;
        if (despawnTimer > despawnTime)
            StartCoroutine(Explode());
    }

    // starts the exlposion coroutine when despawntimer reaches a certain time when the poop hits something
    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(Explode());
    }

    // First turns off a few things on the poop, then plays a particle effect and activates splatter and after a certain ammount of time it destroys the gameobject
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

    // Draws a circle for the splash range
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(gameObject.transform.position, 2);
    }
}
