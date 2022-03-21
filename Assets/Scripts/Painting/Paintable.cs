using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paintable : MonoBehaviour
{

    public GameObject Brush;
    public float BrushSize = 0.1f;

    private float timeRemaining = 5f;
    
    void Start()
    {
        
    }

    void Update()
    {
        if(gameManager.instance.CanPaint){
                if(Input.GetMouseButton(0)){
                    var Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    if(Physics.Raycast(Ray, out hit)){
                        var go = Instantiate(Brush,hit.point + Vector3.up * 0.1f,Quaternion.Euler(-90,0,0),transform);
                        go.transform.localScale = Vector3.one * BrushSize;
                        
                    }
                }

                CheckTimer();
        }
        
    }


    private void CheckTimer(){
        timeRemaining -= Time.deltaTime;

        if(timeRemaining <= 0 ){
            gameManager.instance.OpenEndGameScene();
        }
    }
}
