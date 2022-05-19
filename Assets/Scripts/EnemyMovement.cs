using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f;

    private Transform endPoint;

    private Transform target;
    private int wavepointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        endPoint = GameObject.FindGameObjectWithTag("EndPoint").transform;
        target = Waypoints.points[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(speed * Time.deltaTime * dir.normalized, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.1f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (target == endPoint)
        {
            Destroy(gameObject);
            Health.LoseLife(GetComponent<Enemy>().Damage);
            return;
        }
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            target = endPoint;
            return;
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }
}
