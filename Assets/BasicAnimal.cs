using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicAnimal : MonoBehaviour
{
    NavMeshAgent agent;
    public int navMeshMaskNumber;



    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        Roam();

        StartCoroutine(startRoam());

    }

    IEnumerator startRoam()
    {
        while (true)
        {
            yield return new WaitForSeconds(15);
            Roam();
        }
    }
    
    private void Roam()
    {
        float randomX = Random.Range(-75, 75) + transform.position.x;
        float randomZ = Random.Range(-75, 75) + transform.position.z;
        Vector3 randomPointInBounds = new Vector3(randomX, 0, randomZ);
        NavMeshHit navHit;

        NavMesh.SamplePosition(randomPointInBounds, out navHit, 100, ~navMeshMaskNumber);

        agent.destination = navHit.position;
    }
}
