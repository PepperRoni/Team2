using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Transform target;
    [SerializeField] private float distanceFromTarget;

    #region Unity Overwrites

    private void OnTriggerEnter(Collider other)
    {
        PlayerStats playerStats = other.GetComponent<PlayerStats>();

        if (other.CompareTag("Player") && playerStats)
            playerStats.Die();
    }

    private void Start()
    {
        this.transform.position = target.position - new Vector3(0, distanceFromTarget, 0);
    }

    private void FixedUpdate()
    {
        Vector3 tarPosition = target.position;
        Vector3 myPosition  = this.transform.position;

        this.transform.position = new Vector3(
            tarPosition.x,
            myPosition.y > tarPosition.y - distanceFromTarget ? myPosition.y : tarPosition.y - distanceFromTarget,
            tarPosition.z
        );
    }

    #endregion

    
}
