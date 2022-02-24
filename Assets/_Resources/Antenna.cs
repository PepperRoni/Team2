using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antenna : MonoBehaviour
{
    [SerializeField] GameObject preAntennaPrefab;
    [SerializeField] GameObject particlesPrefab;
    [SerializeField] GameObject doneAntennaPrefab;
    Animator animator;
    void Start()
    {
        animator = preAntennaPrefab.GetComponent<Animator>();
        StartCoroutine(PlayEndAnimation());

    }
    //4.2

    private IEnumerator PlayEndAnimation()
    {
        animator.Play("name");
        yield return new WaitForSeconds(5f);
        yield return null;
    }
}
