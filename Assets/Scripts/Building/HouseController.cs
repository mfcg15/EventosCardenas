using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HouseController : MonoBehaviour
{
    [SerializeField] private UnityEvent onPlayerPositionEnter;
    [SerializeField] private UnityEvent onPlayerPositionExit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            onPlayerPositionEnter?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            onPlayerPositionExit?.Invoke();
        }
    }
}
