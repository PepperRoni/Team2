using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Enviorment")]
    [SerializeField] private Transform tree;
    [SerializeField] private Transform parent;

    [SerializeField] private GameObject prefab;

    [Header("Settings")]

    [SerializeField] private float despawnTime;

    [Tooltip("Adds Y Amount To New Acorn Y Position")]
    [SerializeField] private float yOffset;
    [SerializeField] private float distanceFromTree;

    [Tooltip("Randomizes An Angle Between those 2 Numbers")]
    [SerializeField] private Vector2 betweenAngle;

    [SerializeField] private float spawnTime = 1;
    [SerializeField] private float currentTime;

    #region Unity Overwrites

    private void Update()
    {
        if (currentTime >= spawnTime)
        {
            SpawnObstacle();
            currentTime = 0;
        }
        else
            currentTime += Time.deltaTime;
    }

    #endregion

    float GetRandomAngle()
    {
        float X = betweenAngle.x == 0 ? 1 : betweenAngle.x;
        float Y = betweenAngle.y == 0 ? 361 : betweenAngle.y;

        X = Mathf.FloorToInt(X + 0.5f);
        Y = Mathf.FloorToInt(Y + 0.5f);

        return Random.Range(X, Y);
    }

    void SpawnObstacle()
    {
        GameObject newObstacle = Instantiate(prefab, parent);
        TreeFollower follower = newObstacle.GetComponent<TreeFollower>();

        follower.angle = GetRandomAngle();
        follower.tree = tree;
        follower.distanceFromParent = distanceFromTree;

        newObstacle.transform.rotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
        newObstacle.transform.position = newObstacle.transform.position + new Vector3(0, yOffset, 0);

        Destroy(newObstacle, despawnTime);
    }
}
