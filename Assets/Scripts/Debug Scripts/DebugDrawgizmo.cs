using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DebugDrawgizmo : MonoBehaviour
{
    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 10f);
    }
}
