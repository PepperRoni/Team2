using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    [SerializeField] private float birdSpeed;
    [SerializeField] private float birdResetTime;
    [SerializeField] private GameObject birdGift;

    private bool once;

    RaycastHit hit;
    
    private void Start()
    {
        once = true;
    }

    void Update()
    {
        // Moves and rotates the bird
        gameObject.GetComponent<TreeFollower>().Left(birdSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, gameObject.GetComponent<TreeFollower>().angle, 0);

        // Shoots down a raycast that when it hits the player drops a bird gift
        if (once == true)
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity) && hit.transform.tag == "Player")
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.red);
                DropGift();
                once = false;
                StartCoroutine(BirdGiftReset());
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 1000, Color.white);
            }
        }
    }

    // Instantiates a bird gift prefab at the bird's location
    private void DropGift()
    {
        Instantiate(birdGift, transform.position, Quaternion.identity);
    }

    // Resets the once bool after a set amount of time
    private IEnumerator BirdGiftReset()
    {
        yield return new WaitForSeconds(birdResetTime);
        once = true;
    }
}
