using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DiamondController : MonoBehaviour
{
    public static event Action<int> onCountDiamond;
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            GameManager.diamonds++;
            onCountDiamond?.Invoke(GameManager.diamonds);
            GameManager.instance.IncreseDiamonds();
            Destroy(gameObject);
        }
    }
}
