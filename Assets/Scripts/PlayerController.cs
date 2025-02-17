using Player;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : PlayerBehavior
{
    [SerializeField, Range(0.0f, 1.0f)]
    private float speed = 0.2f;
    
    private float movementX, movementY;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called at a fixed time rate, along with the phisics engine
    private void FixedUpdate()
    {
        Vector3 movementVector = new Vector3(movementX, 0.0f, movementY);
        Vector3 force = movementVector * speed;
        
        Debug.Log($"Applying force: {force}");
        transform.Translate(force, Space.World);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMove(InputValue movementValue)
    {
        var movement = movementValue.Get<Vector2>();
        
        movementX = movement.x;
        movementY = movement.y;
    }
}
