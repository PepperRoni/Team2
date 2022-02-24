using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdGift : MonoBehaviour
{
    [SerializeField] private GameObject poopiEffect;
    [SerializeField] private float despawnTime;
    private float despawnTimer;

    void Start()
    {
        despawnTimer = 0;
    }

    void Update()
    {
        despawnTimer += 1 * Time.deltaTime;
        if (despawnTimer > despawnTime)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider collision)
    {
        GameObject poopi = Instantiate(poopiEffect, this.transform.position, Quaternion.identity);

        GetComponent<Renderer>().enabled = false;

        Destroy(poopi, 2);
        Destroy(gameObject, 0);
    }
}
