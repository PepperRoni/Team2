using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antenna : MonoBehaviour
{
    [SerializeField] GameObject preAntennaPrefab;
    [SerializeField] GameObject ps;
    [SerializeField] GameObject doneAntennaPrefab;
    Animator animator;
    void Start()
    {
       
        

    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Y))
        {
            StartCoroutine(PlayEndAnimation());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();

        if (controller && controller.collectedItems >= 5)
        {
            print("wooo!!!!");
            StartCoroutine(PlayEndAnimation());
        }
        else
        {
            print("Not enough parts :(");
        }
    }

    //4.2
    private IEnumerator PlayEndAnimation()
    {
        GameObject antenna = Instantiate(preAntennaPrefab, this.transform.position, Quaternion.Euler(0, 180, 0));
        animator = preAntennaPrefab.GetComponent<Animator>();
        animator.Play("Shatter");
        yield return new WaitForSeconds(9f);
        Destroy(antenna);
        GameObject particle = Instantiate(ps, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(5f);
        Instantiate(doneAntennaPrefab, this.transform.position, Quaternion.Euler(0, 180, 0));
        Destroy(particle);
        yield return null;
    }
}