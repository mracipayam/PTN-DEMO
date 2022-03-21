using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public Transform target2;
    public Vector3 offset;
    public Vector3 offset2;

    

    
    
    void Start()
    {
        
    }


    void Update()
    {
        if(gameManager.instance.CanPaint){
            transform.position = Vector3.Lerp(transform.position,target2.position + offset2,Time.deltaTime * 3);
        }else{
            transform.position = Vector3.Lerp(transform.position,target.position + offset,Time.deltaTime * 3);
        }

       
    }
}
