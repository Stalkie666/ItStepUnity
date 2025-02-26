using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 2f;

    void Update()
    {
        if( Vector2.Distance( waypoints[currentWaypointIndex].transform.position, transform.position ) < 0.1f  ){
            currentWaypointIndex++;
            currentWaypointIndex %= waypoints.Length;
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, speed * Time.deltaTime);
    }
}
