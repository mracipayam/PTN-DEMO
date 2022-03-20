using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public GameObject RespawnPoint;

    public GameObject FinishLine;

    
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("StaticObstacle") || other.gameObject.CompareTag("MovingObstacle") || other.gameObject.CompareTag("RotatorObstacle")){
            transform.position = RespawnPoint.transform.position;
        }
        if(other.gameObject.CompareTag("RotatingStick")){
            transform.position = RespawnPoint.transform.position;
        }

        
    }

    
    void Update()
    {
        if(transform.position.z >= FinishLine.transform.position.z){
            gameManager.instance.isFinish = true;
        }
    }



    
}
