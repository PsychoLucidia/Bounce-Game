using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementRB : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpPower = 5f;

    [Header("Vector3")]
    public Vector3 moveDirection;

    // Non-Serialized Components
    private Rigidbody _rb;
    private Transform _transform;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _transform = GameObject.Find("LookAtObj").transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _transform.position = this.transform.position;
    }

    void FixedUpdate()
    {
        MoveLogic();
        LimitVelocity();
    }

    void LateUpdate()
    {
    }

    void MoveLogic()
    {
        Vector3 finalMoveDirection = new Vector3(moveDirection.x, 0, 0);

        if (moveDirection.magnitude > 0.1f)
        {
            _rb.velocity = new Vector3(finalMoveDirection.x * moveSpeed, _rb.velocity.y, _rb.velocity.z);
        }
    }

    void LimitVelocity()
    {
        Vector3 currentVelocity = new Vector3(_rb.velocity.x, 0, _rb.velocity.z);

        if (currentVelocity.magnitude > moveSpeed)
        {
            Vector3 limitedVelocity = currentVelocity.normalized * moveSpeed;
            _rb.velocity = new Vector3(limitedVelocity.x, _rb.velocity.y, limitedVelocity.z);
        }
    }

    public void Jump()
    {
        _rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
    }
}
