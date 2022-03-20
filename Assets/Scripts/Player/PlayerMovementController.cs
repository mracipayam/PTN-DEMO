using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    

    [SerializeField]
    private float xBorder;

    public float movementSpeed = 5.75f;

    public float swerveSpeed = 5;

    private PlayerInputController playerInputController;

    

    private float rotationSpeed, horizontalPos, verticalPos;

    private bool isPlaying;
    public bool IsPlaying { set { isPlaying = value; } }

    private Vector3 movementDirection;

    private Transform _transform;

    

    private void Awake()
    {
        playerInputController = GetComponent<PlayerInputController>();
       
    }

    void Start()
    {
        _transform = this.transform;
        
        
    }

    void Update()
    {
        if(gameManager.instance.CanBoyMove){
            MovePlayer();
        }
        
    }

    private void MovePlayer()
    {
        

        movementDirection = playerInputController.MovementDirection;

        if (movementDirection.magnitude >= 0.1f)
        {
            horizontalPos = Mathf.Clamp(movementDirection.normalized.x * swerveSpeed * Time.deltaTime + _transform.position.x, -xBorder, xBorder);
        }

        verticalPos = movementSpeed * Time.deltaTime + _transform.position.z;
        Vector3 movementVector = new Vector3(horizontalPos, 0f, verticalPos);
        _transform.position = movementVector;
        
    }

    
}
