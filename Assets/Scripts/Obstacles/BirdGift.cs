using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdGift : MonoBehaviour
{
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

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
