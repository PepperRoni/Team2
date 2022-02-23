using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [Header("Enviorment")]
    [SerializeField] private Transform target;

    [Header("Settings")]
    [SerializeField] private float distance = 7;
    [SerializeField] private float followSpeed = 5;

    #region Unity Overwrites

    private void FixedUpdate()
    {
        if (target == null)
            return;

        Vector3 lookDirection = (target.position - this.transform.position).normalized;

        this.transform.rotation = Quaternion.LookRotation(lookDirection);

        this.transform.position = Vector3.Lerp(
            this.transform.position,
            target.position + target.forward * distance, 
            Time.deltaTime * followSpeed
        );
    }

    #endregion
}
