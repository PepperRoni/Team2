using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acorn : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float fallingSpeed;
    [SerializeField] private float DestroyTime = 5;

    public Vector3 fixedPosition;

    #region Unity Overwrites

    private void FixedUpdate()
    {
        this.transform.position -= new Vector3(fixedPosition.x, fallingSpeed * Time.deltaTime, fixedPosition.z);
    }

    private void Update()
    {
        CanBeDestroyed();
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    #endregion

    private void CanBeDestroyed()
    {
        Vector3 acornPosition = Camera.main.WorldToScreenPoint(transform.position);

        if (this.transform.position.y < Camera.main.transform.position.y && !Screen.safeArea.Contains(acornPosition))
            Destroy(this.gameObject, DestroyTime);
    }
}
