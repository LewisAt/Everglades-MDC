//Ian Marshburn
//Script handles the handheld or stationary trashcan destroying trash and updating the GameDataManager
//An extremely simple script. Can easily be added on to if necessary
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("trash"))
        {
            GameDataManager.Instance.trashRemaining--;

            Destroy(other.gameObject);
        }

    }
}
