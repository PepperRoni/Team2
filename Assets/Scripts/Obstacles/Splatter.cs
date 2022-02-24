using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splatter : MonoBehaviour
{
    [SerializeField] private GameObject splatterImage;
    private bool once;

    private void Start()
    {
        once = true;
        splatterImage.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && once == true)
        {
            once = false;
            splatterImage.SetActive(true);
        }
        else
            StartCoroutine(MissSplash());
    }

    private IEnumerator MissSplash()
    {
        yield return new WaitForSeconds(0.1f);
        once = false;
    }
}
