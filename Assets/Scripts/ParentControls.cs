using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentControls : MonoBehaviour
{
    // Input Actions for controls
    protected MainControls mainControls;
    protected Rigidbody rb;

    // Speed for movement
    [SerializeField] protected float speed;


    // Initiate parentControls
    protected virtual void Awake()
    {
        mainControls = new MainControls();
        rb = GetComponent<Rigidbody>();
    }

    // Enable parentControls
    private void OnEnable()
    {
        mainControls.Enable();
    }

    // disable parentControls
    private void OnDisable()
    {
        mainControls.Disable();
    }

    // function used to move the entity based on wasd input
    // moves through rigidbody by setting velocity
    protected virtual void MoveEntity()
    {
        Vector3 move = mainControls.Main.Move.ReadValue<Vector3>() * speed * Time.fixedDeltaTime;
        Vector3 fly = mainControls.Ghost.Fly.ReadValue<Vector3>() * speed * Time.fixedDeltaTime;
        rb.MovePosition(move + fly + transform.position);
        
    }

    // handles movement of the player
    protected virtual void FixedUpdate()
    {
        MoveEntity();
    }

}
