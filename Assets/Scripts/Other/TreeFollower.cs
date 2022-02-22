using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeFollower : MonoBehaviour
{
    [Header("Enviorment")]
    public Transform tree;

    [Header("Settings")]
    public float distanceFromParent = 5;
    public float angle;

    #region Unity Overwrites

    private void Update()
    {
        UpdateTarget();
    }

    // Some checks to see if tree exists n stuff
    private void Start()
    {
        if (tree != null)
            return;

        Debug.LogWarning($"No Tree Select, {this.gameObject.name} ");

        GameObject foundTree = GameObject.FindGameObjectWithTag("Tree");

        if (foundTree)
            tree = foundTree.transform;
        else
        {
            Debug.LogError("NO TREE FOUND WITH TAG!!!");

            Destroy(this);

            return;
        }
    }

    #endregion

    // Will calculate the exact position and rotation for the object
    Vector3 CalculatePosition()
    {
        return tree.position + (Quaternion.Euler(0, angle, 0) * Vector3.forward * distanceFromParent); ;
    }

    // Updates the Target
    void UpdateTarget()
    {
        Vector3 newPosition = CalculatePosition();
        Vector3 myPosition  = this.transform.position;

        this.transform.position = new Vector3(newPosition.x, myPosition.y, newPosition.z);
    }

    public void Left (float amount)  { angle -= amount; }
    public void Right(float amount) { angle += amount; }
}
