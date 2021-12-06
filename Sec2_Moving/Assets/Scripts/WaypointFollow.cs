using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollow : MonoBehaviour
{
    public GameObject[] waypoints;

    private int currentWP;

    private float speed = 1.0f;

    private float accuracy = 1f;

    private float rotSpeed = 0.4f;
    
    // Start is called before the first frame update
    void Start()
    {
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
    }

    void LateUpdate()
    {
        if (waypoints.Length == 0) return;
        
        Vector3 lookAtGoal = new Vector3(waypoints[currentWP].transform.position.x, transform.position.y, waypoints[currentWP].transform.position.z);

        Vector3 direction = lookAtGoal - transform.position;
        
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction),Time.deltaTime * rotSpeed );

        if (direction.magnitude < accuracy)
        {
            currentWP++;
            if (currentWP >= waypoints.Length)
            {
                currentWP = 0;
            }
        }
        transform.Translate(0,0, speed * Time.deltaTime);
    }
}
