using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [Header("Enviorment")]
    [SerializeField] private Transform target;
    [SerializeField] private Transform tree;

    [Header("Settings")]
    [SerializeField] private Vector3 targetOffset;
    [SerializeField] private Vector3 cameraOffset;
    [SerializeField] private float distance = 7;
    [SerializeField] private float followSpeed = 5;

    #region Unity Overwrites

    private void FixedUpdate()
    {
        if (target == null || !target.GetComponent<TreeFollower>())
            return;

        TreeFollower treeFollower = target.GetComponent<TreeFollower>();

        Vector3 newPosition = CalculatePosition(treeFollower.angle, distance);
        Vector3 lookDirection = (target.position - this.transform.position).normalized;

        this.transform.rotation = Quaternion.Lerp(
            this.transform.rotation,
            Quaternion.LookRotation(lookDirection) * Quaternion.Euler(targetOffset),
            Time.deltaTime * followSpeed
        );

        this.transform.position = Vector3.Lerp(
            this.transform.position,
            new Vector3(newPosition.x, target.position.y, newPosition.z) + cameraOffset,
            Time.deltaTime * followSpeed
        );
    }

    #endregion

    Vector3 CalculatePosition(float angle, float distance)
    {
        return tree.position + (Quaternion.Euler(0, angle, 0) * (Vector3.forward * distance)); ;
    }
}
