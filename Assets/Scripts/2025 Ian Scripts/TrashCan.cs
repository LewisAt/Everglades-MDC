//Ian Marshburn
//Script handles the handheld or stationary trashcan destroying trash and updating the GameDataManager
//An extremely simple script. Can easily be added on to if necessary
//NOTE: put this on a large trigger collider underneath the map in case the trash falls through the terrain
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("trash"))
        {
            GameDataManager.Instance.ReduceTrash();

            Destroy(other.gameObject);
        }

    }
}
