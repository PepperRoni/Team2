using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour, IInteractable
{
    private bool collected;

    public void Interact(PlayerController player)
    {
        if (!collected)
        {
            collected = true;
            player.collectedItems++;
            Destroy(this.gameObject);
        }
    }
}