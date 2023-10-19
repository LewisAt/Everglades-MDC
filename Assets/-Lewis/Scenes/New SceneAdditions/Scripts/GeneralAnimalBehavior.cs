using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class GeneralAnimalBehavior : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject walkingbounds;
    public string AnimalToHuntByTag;
    public bool canHunt = false;

    private float boundsX;
    private float boundsZ;
    
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        spawned();
        boundsX = walkingbounds.GetComponent<BoxCollider>().bounds.size.x;
        boundsZ = walkingbounds.GetComponent<BoxCollider>().bounds.size.z;
        Debug.Log(boundsX);
    }
    private void Start()
    {
        Roam();

    }
    IEnumerator Actions()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
        }
    }
    public void killed()
    {
        TrackAnimalCount.RemoveFromCount(this.tag);
        Destroy(this.gameObject);

    }
    public void spawned()
    {
        TrackAnimalCount.addtoPopulationCount(this.tag);
    }
    private void Roam()
    {
        float randomX = Random.Range(walkingbounds.transform.position.x - (boundsX * 0.5f), walkingbounds.transform.position.x + (boundsX * 0.5f));
        float randomZ = Random.Range(walkingbounds.transform.position.z - (boundsZ * 0.5f), walkingbounds.transform.position.z + (boundsZ * 0.5f));
        Vector3 randomPointInBounds = new Vector3(randomX, 0, randomZ);
        agent.destination = randomPointInBounds;
    }
    private void Hunt()
    {
        
    }

}
