using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Opponent : MonoBehaviour
{
    
    public GameObject Point;
    private float randomSpeed;

    public GameObject RespawnPoint;

    NavMeshAgent agent;

    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        randomSpeed = Random.Range((float)0.5, (float)1.5);
        agent.speed = randomSpeed;
    }

    
    void Update()
    {
        if(gameManager.instance.CanOpponentMove == true){
            agent.SetDestination(Point.transform.position);
            
        }
    }


    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("StaticObstacle") || other.gameObject.CompareTag("MovingObstacle") || other.gameObject.CompareTag("RotatorObstacle")){
            transform.position = RespawnPoint.transform.position;
        }
        if(other.gameObject.CompareTag("RotatingStick")){
            transform.position = RespawnPoint.transform.position;
        }
    }
}
