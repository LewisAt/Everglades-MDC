using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicAnimal : MonoBehaviour
{
    NavMeshAgent agent;
    private GameObject ModelToMove;
    private Vector3 DefaultModelPositon;
    public int navMeshMaskNumber;
    public float MovementStrength = 1f;
    public bool waddle = false;

    private float MovementDirection = 0;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        ModelToMove = this.transform.GetChild(0).gameObject;
        DefaultModelPositon = ModelToMove.transform.localPosition;
        Roam();

        StartCoroutine(startRoam());
        

    }
    void fixStartPosition()
    {
        Ray FixRay = new Ray();
    }
    private void Update()
    {
        CalculateDirection();
        Debug.Log(MovementDirection);
        waddleAnimation();
    }

    float temp = 0f;
    bool flip;
    void CalculateDirection()
    {
        if (temp >= 0.1f)
        {
            flip = true;
        }
        if (temp <= -0.1f) 
        {
            flip = false;
        }
        if(flip)
        {
            temp -= Time.deltaTime;
        }
        else if(!flip)
        {
            temp += Time.deltaTime;
        }
        MovementDirection = temp;
    }
    void waddleAnimation()
    {
        if(agent.velocity.sqrMagnitude > 0.1f)
        {
            // up motion
            float MotionAdition = (Time.deltaTime * (MovementStrength * MovementDirection)) ;
            ModelToMove.transform.localPosition = new Vector3(DefaultModelPositon.x,DefaultModelPositon.y + MotionAdition,DefaultModelPositon.z);     
        }
        else
        {
            return;
        }
    }
    IEnumerator startRoam()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(2,10));
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
