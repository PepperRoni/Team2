using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TreeFollower))]
public class Bug : MonoBehaviour
{
    [Header("Wander Settings")]
    [SerializeField] private bool wanderEnabled;
    [SerializeField] private float k;
}
