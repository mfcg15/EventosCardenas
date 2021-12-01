using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    bool openDoor;
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if(openDoor)
        {
            Quaternion rotation = Quaternion.Euler(0, 360, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, rotation, 10f * Time.deltaTime);

            if ((Vector3.Distance(player.transform.position, transform.position) > 3.5f))
            {
                openDoor = false;
            }
        }
        else
        {
            Quaternion rotation = Quaternion.Euler(0, 270, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, rotation, 10f * Time.deltaTime);
        }

    }

    public void SystemDoor (bool status)
    {
        openDoor = status;
    }
}
