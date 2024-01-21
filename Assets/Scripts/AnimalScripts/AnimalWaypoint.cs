using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class AnimalWaypoint : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 0.3f;

    private int current = 0;
    private quaternion lookRotation;
    public float RotationSpeed = 1f;
    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    private void FixedUpdate()
    {
        if (transform.position != waypoints[current].position)
        {
            Vector3 position = Vector3.MoveTowards(transform.position, waypoints[current].position, speed);
            GetComponent<Rigidbody>().MovePosition(position);
        }
        else
        {
            current = (current + 1) % waypoints.Length;
        }
        
        Vector3 direction = waypoints[current].position - transform.position;
        lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * RotationSpeed);
    }
}