using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acorn : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float fallingSpeed;
    [SerializeField] private float DestroyTime = 5;

    #region Unity Overwrites

    private void FixedUpdate()
    {
        Vector3 myPosition = this.transform.position;

        this.transform.position -= new Vector3(myPosition.x, fallingSpeed * Time.deltaTime, myPosition.z);
    }

    private void Update()
    {
        CanBeDestroyed();
    }

    #endregion

    private void CanBeDestroyed()
    {
        Vector3 acornPosition = Camera.main.WorldToScreenPoint(transform.position);

        if (this.transform.position.y < Camera.main.transform.position.y && !Screen.safeArea.Contains(acornPosition))
            Destroy(this.gameObject, DestroyTime);
    }
}
