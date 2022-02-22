using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    [Header("Bird Stats")]
    [SerializeField] private float birdSpeed;
    [SerializeField] private float birdResetX;
    [SerializeField] private float birdResetY;

    [Header("Bird Timer")]
    [SerializeField] private float birdTimer;
    [SerializeField] private float birdTimerGoalOne;
    [SerializeField] private float birdTimerGoalTwo;

    [SerializeField] private GameObject birdGift;

    private bool once;

    RaycastHit hit;

    void Start()
    {
        ResetBird();
    }

    void Update()
    {
        birdTimer += 1 * Time.deltaTime;

        if (birdTimer < birdTimerGoalOne)
            transform.position = new Vector3(transform.position.x - (birdSpeed * Time.deltaTime), transform.position.y, transform.position.z);

        if (birdTimer > birdTimerGoalTwo)
            ResetBird();

        if (once == true)
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity) && hit.transform.tag == "Player")
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.red);
                DropGift();
                once = false;
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 1000, Color.white);
            }
        }
    }

    private void DropGift()
    {
        Instantiate(birdGift, transform.position, Quaternion.identity);
    }

    private void ResetBird()
    {
        once = true;
        birdTimer = 0;
        transform.position = new Vector3(birdResetX, birdResetY, 0);
    }
}
