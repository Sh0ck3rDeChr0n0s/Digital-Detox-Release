using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyWalk : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] [Range(0, 20)] private float _agentSpeed;
    [SerializeField][Range(5,20)] private float _wanderRadius = 10f;
    [SerializeField][Range(1,10)] private float _wanderInterval = 3f;
    [SerializeField] GameObject _player;
    [SerializeField][Range(0,100)] private float _distanceToRun;

    private float _distance;
    private float _timer;

    private void Start()
    {
        _timer = _wanderInterval;
        _agent ??= GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        _distance = Vector3.Distance(transform.position, _player.transform.position);
        if (_distance < _distanceToRun)
        {
            _agent.speed = _agentSpeed;
            _agent.SetDestination(Run(transform.position, 30f));
        }
        else
        {
            _timer += Time.deltaTime;

            if (_timer >= _wanderInterval)
            {
                Vector3 newWanderPosition = RandomNavSphere(transform.position, _wanderRadius);
                _agent.SetDestination(newWanderPosition);
                _timer = 0;
                _agent.speed = 2.5f;
            }
        }
    }
    private static Vector3 RandomNavSphere(Vector3 origin, float distance)
    {
        Vector3 randomDirection = Random.insideUnitSphere * distance;
        randomDirection += origin;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randomDirection, out navHit, distance, NavMesh.AllAreas);

        return navHit.position;
    }
    private Vector3 Run(Vector3 origin, float distance)
    {
        Vector3 randomDirection = transform.position + (transform.position - _player.transform.position).normalized * 30f;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randomDirection, out navHit, distance, NavMesh.AllAreas);

        return navHit.position;
    }
}
