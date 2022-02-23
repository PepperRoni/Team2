using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeFollower : MonoBehaviour
{
    [Header("Enviorment")]
    public Transform tree;

    [Header("Settings")]
    public bool isStatic;
    public float distanceFromParent = 5;
    public float angle;

    [Header("Move Settings")]
    public float moveSpeed = 5;
    public bool smoothMovement;

    #region Unity Overwrites

    private void Update()
    {
        if (!isStatic)
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

        if (isStatic)
            UpdateTarget();
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

        Vector3 outputPosition = new Vector3(newPosition.x, myPosition.y, newPosition.z);

        this.transform.position = smoothMovement ? Vector3.Lerp(myPosition, outputPosition, Time.deltaTime * moveSpeed) : outputPosition;
    }

    public void Left (float amount) { angle -= amount; }
    public void Right(float amount) { angle += amount; }
}
