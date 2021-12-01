using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SystemDoor : MonoBehaviour
{
    [SerializeField] private UnityEvent onSystemDoor;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            onSystemDoor?.Invoke();
        }
    }
}
