using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcornSpawner : MonoBehaviour
{
    [Header("Enviorment")]
    [SerializeField] private Transform tree;

    [SerializeField] private GameObject acornPrefab;
    [SerializeField] private Transform  acornParent;

    [Header("Settings")]
    [SerializeField] private float spawnTime;
    [SerializeField] private float currentTime;

    #region Unity Overwrites

    private void Update()
    {
        if (currentTime >= spawnTime)
        {
            SpawnAcorn();
            currentTime = 0;
        }
        else
            currentTime += Time.deltaTime;
    }

    #endregion

    float GetRandomAngle() { return Random.Range(1, 361); }

    void SpawnAcorn()
    {
        GameObject newAcorn   = Instantiate(acornPrefab, acornParent);
        TreeFollower follower = newAcorn.GetComponent<TreeFollower>();

        follower.angle = GetRandomAngle();
        follower.tree  = tree;
        follower.distanceFromParent = 13;
    }
}
