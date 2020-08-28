using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointSystemPath : MonoBehaviour
{
    public Color linecolor;

    public List<Transform> waypoint = new List<Transform>();

    
    void OnDrawGizmos()
    {
        Gizmos.color = linecolor;
        // making a waypoint system using parent-child relationship
        Transform[] pathTransform = GetComponentsInChildren<Transform>();
        waypoint = new List<Transform>();
        // gets the index for each child in the system
        for(int i = 0; i < pathTransform.Length; i++)
        {
            if (pathTransform[i] != transform)
            {
                waypoint.Add(pathTransform[i]);
            }
        }

        // creates the path for the waypoints
        for (int j = 0; j < waypoint.Count; j++)
        {
            //gets the current position of the waypoint
            Vector3 currentWayPoint = waypoint[j].position;
            Vector3 previousWayPoint = Vector3.zero;
            // to connect the last waypoint (n?) to the current node which is 0(zero) so that it will form the path
            if (j> 0)
            {
                //waypoint zero
                previousWayPoint = waypoint[j-1].position;
            }else if (j == 0 && waypoint.Count > 1)
            {
                // takes the last waypoint in the list
                previousWayPoint = waypoint[waypoint.Count - 1].position;
            }
            
            Gizmos.DrawLine(previousWayPoint, currentWayPoint);
            Gizmos.DrawWireSphere(currentWayPoint, 0.2f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

}

