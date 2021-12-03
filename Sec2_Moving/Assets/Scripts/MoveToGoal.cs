using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToGoal : MonoBehaviour
{
    public float speed = 2.0f;
    public float accuracy = 0.2f;
    public Transform goal;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(goal.position);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 direction = goal.position - transform.position;
        Debug.DrawRay(transform.position, direction, Color.red);
        if (direction.magnitude > accuracy)
        {
            transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        }
       
    }
}
