using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [Header("Enviorment")]
    [SerializeField] private Transform target;
    [SerializeField] private Transform tree;

    [Header("Settings")]
    [SerializeField] private bool enabled;

    [SerializeField] private Vector3 targetOffset;
    [SerializeField] private Vector3 cameraOffset;

    [SerializeField] private float distance = 7;
                     private float followSpeed = 5;

    #region Unity Overwrites

    private void Start()
    {
        TreeFollower treeFollower = target.GetComponent<TreeFollower>();

        Vector3 newPosition   = CalculatePosition(treeFollower.angle, distance);

        this.transform.rotation = Quaternion.Euler(90, 0, 0);
        this.transform.position = new Vector3(newPosition.x, target.position.y + 400, newPosition.z);

        StartCoroutine(StartCamera());
    }

    private void FixedUpdate()
    {
        if (target == null || !target.GetComponent<TreeFollower>() || enabled == false)
            return;

        TreeFollower treeFollower = target.GetComponent<TreeFollower>();

        Vector3 lookDirection = (target.position - this.transform.position).normalized;
        Vector3 newPosition   = CalculatePosition(treeFollower.angle, distance);

        this.transform.rotation = Quaternion.Lerp(
            this.transform.rotation,
            Quaternion.LookRotation(lookDirection) * Quaternion.Euler(targetOffset),
            Time.deltaTime * followSpeed
        );

        this.transform.position = Vector3.Lerp(
            this.transform.position,
            new Vector3(newPosition.x, target.position.y + cameraOffset.y, newPosition.z),
            Time.deltaTime * followSpeed
        );
    }

    #endregion

    IEnumerator StartCamera()
    {
        yield return new WaitForSeconds(2);

        followSpeed = 2;
        enabled = true;

        yield return new WaitForSeconds(3.5f);
        followSpeed = 5;
    }

    Vector3 CalculatePosition(float angle, float distance)
    {
        return tree.position + (Quaternion.Euler(0, angle, 0) * (Vector3.forward * distance));
    }
}
