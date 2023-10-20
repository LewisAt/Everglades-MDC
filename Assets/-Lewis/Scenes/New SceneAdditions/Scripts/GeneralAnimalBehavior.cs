using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class GeneralAnimalBehavior : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject EdibleAnimals;
    public int navMeshMaskNumber;
    public string AnimalToHuntByTag;
    public bool canHunt = false;
    private bool ishunting = false;
    public int ViewingRadius = 20;



    private void Awake()
    {
        agent = GetComponentInParent<NavMeshAgent>();
        spawned();
    }
    private void Start()
    {
        
        //StartCoroutine(RandomActions());
        Roam();
        StartCoroutine(RandomActions());

    }
    private void Update()
    {

        

        if (ishunting)
        {
            Hunt();
        }
    }


    IEnumerator RandomActions()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5f,20f));
            if (Random.value > 0.90f && canHunt && !ishunting && EdibleAnimals != null)
            {
                ishunting = true;
            }
            else
            {
                Roam();
            }
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag + " : " + AnimalToHuntByTag + " : " + ishunting + " : " + this.gameObject.transform.parent.name);
        if (other.tag == AnimalToHuntByTag  && canHunt && !ishunting)
        {
            PredatorDebug("Prey was added");
            EdibleAnimals = other.gameObject;

        }
        if(Random.value > 0.85f && canHunt && other.tag == AnimalToHuntByTag)
        {
            PredatorDebug("Prey was added through chance");

            EdibleAnimals = other.gameObject;
        }    
    }
    public void killed()
    {
        Debug.Log("Iwas killed :(");
        TrackAnimalCount.RemoveFromCount(this.tag);
        Destroy(this.transform.parent.gameObject);

    }
    public void spawned()
    {
        TrackAnimalCount.addtoPopulationCount(this.tag);
    }
    private void Roam()
    {
        float randomX = Random.Range(-75,75) + transform.position.x;
        float randomZ = Random.Range(-75, 75) + transform.position.z;
        PredatorDebug("roaming");
        Vector3 randomPointInBounds = new Vector3(randomX, 0, randomZ);
        NavMeshHit navHit;

        NavMesh.SamplePosition(randomPointInBounds, out navHit, 100,~navMeshMaskNumber);

        agent.destination = navHit.position;
    }

    private void Hunt()
    {
        PredatorDebug("Hunt is being called");
        if(EdibleAnimals!= null) 
        {
            PredatorDebug("FOOD IS FOUND WE NOW FEAST!");

            agent.destination = EdibleAnimals.transform.position;
        }
        else if(EdibleAnimals == null)
        {
            ishunting = false;
        }
    }
    public void switchHuntingStates(bool state)
    {
        ishunting = state;
    }
    void PredatorDebug(string debug)
    {
        if (canHunt)
        {
            Debug.Log(debug);

        }
    }

}
