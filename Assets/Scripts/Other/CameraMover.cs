using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [Header("Enviorment")]
    [SerializeField] private Transform target;

    #region Unity Overwrites

    private void Update()
    {
        if (target == null)
            Debug.LogWarning("No Target Selected");
    }

    private void FixedUpdate()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, target.position, Time.deltaTime);
    }

    #endregion
}
