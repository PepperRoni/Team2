using System.Collections;
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

    // Triggers de splatter effect when the player is in the splash range of the poop
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

    // Makes it so that the splatter effect can't be activated after the poop misses the player
    private IEnumerator MissSplash()
    {
        yield return new WaitForSeconds(0.1f);
        once = false;
    }
}
