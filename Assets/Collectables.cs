using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour, IInteractable
{
    public void Interact(PlayerController player)
    {
        player.collectedItems++;
        Destroy(this.gameObject);
    }
}