using UnityEngine;

public class Waypoints : MonoBehaviour
{

    public GameObject[] waypoints;
    int current = 0;
    public float speed = 1f;
    float waypointRadius = 1f;

    void Update()
    {
        if(Vector3.Distance(waypoints[current].transform.position,transform.position)< waypointRadius){
            current++;
            if(current >= waypoints.Length){
                current=0;
            }
        }
        transform.position=Vector3.MoveTowards(transform.position,waypoints[current].transform.position,Time.deltaTime * speed);
    }
}
