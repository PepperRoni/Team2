using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TreeFollower))]
public class Bug : MonoBehaviour
{
    [Header("Wander Settings")]
    [SerializeField] private bool wanderEnabled;

    [Tooltip("X amount of seconds before it get's a  new position")]
    [SerializeField] private float wanderTime;
    [SerializeField] private float currentTime;

    private TreeFollower treeFollower;

    #region Unity Overwrites

    private void Awake()
    {
        treeFollower = this.GetComponent<TreeFollower>();
    }

    private void FixedUpdate()
    {
        if (currentTime >= wanderTime)
        {
            currentTime = 0;
            StartCoroutine(LerpMovement());
        }

        currentTime = wanderEnabled ? currentTime + Time.deltaTime : 0;
    }

    #endregion

    IEnumerator LerpMovement()
    {
        float X = Random.Range(-2, 2);
        float Y = Random.Range(-2, 2);

        X += this.transform.position.x;
        Y += this.transform.position.y;

        for (int i = 0; i < 25; i++)
        {
            yield return new WaitForSecondsRealtime(0.05f);

            treeFollower.Right(0.2f);

            this.transform.position = new Vector3(
                this.transform.position.x,
                Mathf.Lerp(this.transform.position.y, Y, 0.04f),
                this.transform.position.z
            );
        }
    }
}
