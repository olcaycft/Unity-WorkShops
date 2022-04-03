using System;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
    public GameObject player;
    public Transform receiver;

    private bool playerIsTeleporting;

    // Update is called once per frame
    void Update()
    {
        if (!playerIsTeleporting) return;
        Teleporting();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            playerIsTeleporting = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            playerIsTeleporting = false;
        }
    }

    private void Teleporting()
    {
        if (playerIsTeleporting)
        {
            Vector3 portalToPlayer = player.transform.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            //if this is true player can teleport other wise that means player comes from other side to portal
            if (dotProduct < 0f)
            {
                //teleport player
                float rotationDiff = -Quaternion.Angle(transform.rotation, receiver.rotation);
                rotationDiff += 180;
                player.transform.Rotate(Vector3.up, rotationDiff);

                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                player.transform.position = receiver.position + positionOffset;
                playerIsTeleporting = false;
            }
        }
    }
}