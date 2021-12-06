using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLocal : MonoBehaviour
{
    public Transform goal;

    public float speed = 0.5f;
    public float accuracy = 1.0f;
    public float rotSpeed = 0.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 lookAtGoal = new Vector3(goal.position.x, transform.position.y, goal.position.z);

        Vector3 direction = lookAtGoal - transform.position;
        
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction),Time.deltaTime * rotSpeed );
        if (Vector3.Distance(transform.position, lookAtGoal) > accuracy)
        {
            transform.Translate(0,0, speed * Time.deltaTime);
        }
        
    }
}
