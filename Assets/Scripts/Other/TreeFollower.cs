using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeFollower : MonoBehaviour
{
    [Header("Enviorment")]
    [SerializeField] private Transform tree;

    [Header("Settings")]
    [SerializeField] private float distanceFromParent = 5;
    [SerializeField] private float angle;

    #region Unity Overwrites

    private void FixedUpdate()
    {
        UpdateTarget();
    }

    // Some checks to see if tree exists n stuff
    private void Awake()
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
        Vector3 myPosition = this.transform.forward;

        this.transform.rotation = Quaternion.Euler(0, angle, 0);

        myPosition.x *= distanceFromParent;
        myPosition.z *= distanceFromParent;

        return tree.position + myPosition;
    }

    // Updates the Target
    void UpdateTarget()
    {
        var (newPosition, myPosition) = (CalculatePosition(), this.transform.position);

        this.transform.position = new Vector3(newPosition.x, myPosition.y, newPosition.z);
    }

    public void Left(float amount) { angle -= amount; }
    public void Right(float amount) { angle += amount; }
}
