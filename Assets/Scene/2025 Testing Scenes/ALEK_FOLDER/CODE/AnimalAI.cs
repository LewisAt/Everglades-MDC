using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Handles NavMesh-based AI movement for animals and prefab switching for idle state.
/// </summary>
public class AnimalAI : MonoBehaviour
{
    public Animator animator;
    public float walkRadius = 10f;
    public float waitTime = 5f;

    private NavMeshAgent agent;
    private float timer;
    private bool isIdle = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = waitTime;
        GoToRandomPosition();
    }

    void Update()
    {
        if (isIdle) return;

        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                GoToRandomPosition();
                timer = waitTime;
            }
        }

        if (animator != null)
        {
            animator.SetFloat("Speed", agent.velocity.magnitude);
        }
    }

    /// <summary>
    /// Sends the animal to a random NavMesh location.
    /// </summary>
    void GoToRandomPosition()
    {
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * walkRadius + transform.position;

        if (NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, walkRadius, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
    }

    /// <summary>
    /// Switches this animal to an idle prefab (sitting version).
    /// </summary>
    public void SwitchToIdle(GameObject idlePrefab)
    {
        isIdle = true;
        Instantiate(idlePrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    /// <summary>
    /// Resumes random walking after being idle.
    /// </summary>
    public void ResumeWalking()
    {
        isIdle = false;
        GoToRandomPosition();
    }

    /// <summary>
    /// Moves animal to a specific world position (used by spawner or summon).
    /// </summary>
    public void MoveToPlayer(Vector3 position)
    {
        if (agent != null && !isIdle)
        {
            agent.SetDestination(position);
        }
    }
}