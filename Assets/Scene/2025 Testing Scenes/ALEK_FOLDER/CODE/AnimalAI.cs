using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimalAI : MonoBehaviour
{
    public Transform[] waypoints;  // Array of waypoints for movement
    private int currentWaypointIndex = 0;
    private NavMeshAgent agent;

    public float pauseTime = 40f; // Time to stop for player interaction
    private bool isPaused = false;
    private bool isInteracting = false; // Checks if player is interacting

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        MoveToNextWaypoint();
    }

    void Update()
    {
        if (!isPaused && agent.remainingDistance < 1f && !agent.pathPending)
        {
            StartCoroutine(PauseAtWaypoint());
        }
    }

    IEnumerator PauseAtWaypoint()
    {
        isPaused = true;
        agent.isStopped = true;

        yield return new WaitForSeconds(pauseTime);

        if (!isInteracting) // Only move if player isn't interacting
        {
            MoveToNextWaypoint();
        }
    }

    void MoveToNextWaypoint()
    {
        if (waypoints.Length == 0) return;

        agent.destination = waypoints[currentWaypointIndex].position;
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;

        agent.isStopped = false;
        isPaused = false;
    }

    public void StartInteraction()
    {
        isInteracting = true;
        agent.isStopped = true;
    }

    public void EndInteraction()
    {
        isInteracting = false;
        MoveToNextWaypoint();
    }

    // 🔹 ADD THIS METHOD BELOW (New Method for Moving to Player)
    public void MoveToPlayer(Vector3 targetPosition)
    {
        if (agent != null)
        {
            agent.isStopped = false;
            agent.SetDestination(targetPosition);
        }
    }
}
