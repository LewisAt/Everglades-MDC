using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System;

public class AnimalAI : MonoBehaviour
{
    public Transform waypointsParent;  // Parent object holding all waypoints
    private List<Transform> waypoints = new List<Transform>(); // List to store waypoints

    public float moveSpeed = 3.5f;
    public float stopDuration = 40f;

    private int currentWaypointIndex = 0;
    private bool movingForward = true;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = moveSpeed;

        if (waypointsParent != null)
        {
            foreach (Transform child in waypointsParent)
            {
                waypoints.Add(child);
            }
        }

        if (waypoints.Count > 0)
        {
            agent.SetDestination(waypoints[currentWaypointIndex].position);
            StartCoroutine(WaypointLoop());
        }
    }

    private IEnumerator WaypointLoop()
    {
        while (true)
        {
            if (waypoints.Count == 0) yield break;

            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                yield return new WaitForSeconds(stopDuration);

                if (movingForward)
                {
                    currentWaypointIndex++;
                    if (currentWaypointIndex >= waypoints.Count)
                    {
                        currentWaypointIndex = waypoints.Count - 2;
                        movingForward = false;
                    }
                }
                else
                {
                    currentWaypointIndex--;
                    if (currentWaypointIndex < 0)
                    {
                        currentWaypointIndex = 1;
                        movingForward = true;
                    }
                }

                agent.SetDestination(waypoints[currentWaypointIndex].position);
            }

            yield return null;
        }
    }

    public void MoveToPlayer(Vector3 position)
    {
        StopAllCoroutines();
        agent.SetDestination(position);
    }
}