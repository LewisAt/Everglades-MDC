using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMechanic : MonoBehaviour
{
    public GeneralAnimalBehavior GeneralAnimalInfo;
    private bool canHunt = false;
    private Collider baseCollider;
    private void Awake()
    {
        canHunt = GeneralAnimalInfo.canHunt;
        baseCollider = GetComponent<Collider>();
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<GeneralAnimalBehavior>() !=null)
        {
            Debug.Log("I am the outershell");
            return;
        }
        if (other.gameObject.tag == GeneralAnimalInfo.AnimalToHuntByTag && canHunt)
        {
            Debug.Log(other.gameObject.transform.parent.name);
            Debug.Log("I am : " + this.gameObject.transform.parent.name);
            GeneralAnimalInfo.switchHuntingStates(false);
            other.GetComponent<AttackMechanic>().GeneralAnimalInfo.killed();
        }
    }
}
