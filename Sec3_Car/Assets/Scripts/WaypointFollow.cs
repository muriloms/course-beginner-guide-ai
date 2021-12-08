using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class WaypointFollow : MonoBehaviour
{
    public WaypointCircuit circuit;

    private int currentWP = 0;

    private float speed = 3.0f;

    private float accuracy = 1.0f;

    private float rotSpeed = 1.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void LateUpdate()
    {
        if (circuit.Waypoints.Length == 0) return;

        Vector3 lookAtGoal = new Vector3(circuit.Waypoints[currentWP].position.x,
            transform.position.y,
            circuit.Waypoints[currentWP].position.z);

        Vector3 direction = lookAtGoal - transform.position;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction),
            Time.deltaTime * rotSpeed);

        if (direction.magnitude < accuracy)
        {
            currentWP++;
            if (currentWP >= circuit.Waypoints.Length)
            {
                currentWP = 0;
            }
        }
        
        transform.Translate(0,0,speed * Time.deltaTime);

    }
}
