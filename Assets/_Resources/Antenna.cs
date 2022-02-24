using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antenna : MonoBehaviour
{
    [SerializeField] GameObject preAntennaPrefab;
    //[SerializeField] GameObject ps;
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
    //4.2
    private IEnumerator PlayEndAnimation()
    {
        Instantiate(preAntennaPrefab, transform);
        animator = preAntennaPrefab.GetComponent<Animator>();
        animator.Play("Shatter");
        yield return new WaitForSeconds(5f);
        Destroy(preAntennaPrefab);
        //ps.Play();
        yield return new WaitForSeconds(2f);
        Instantiate(doneAntennaPrefab, transform);
        yield return null;
    }
}