using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement
{
    private Rigidbody2D rigidbody;
    private MovementConfig config;

    private float groundAngle;
    public float GroundAngle => groundAngle;

    private const string groundLayerName = "Ground";
    private LayerMask groundLayer;

    public Movement(Rigidbody2D rigidbody, MovementConfig movementConfig)
    {
        this.rigidbody = rigidbody;
        this.config = movementConfig;

        groundLayer = LayerMask.GetMask(groundLayerName);
    }

    public void Move(float horizontalInput)
    {
        CheckGround(false, .8f);
        if (GroundAngle > 40)
        {
            return;
        }

        if (horizontalInput != 0)
        {
            Rotate(horizontalInput);
        }

        rigidbody.AddForce(new Vector2(config.MovementSpeed * horizontalInput, 0), ForceMode2D.Impulse);

        Vector3 clampVelocity = rigidbody.velocity;
        clampVelocity.x = Mathf.Clamp(clampVelocity.x, -config.MovementSpeed, config.MovementSpeed);
        rigidbody.velocity = clampVelocity;
    }

    public bool CheckGround(bool snap = true, float rayDistance = 1f)
    {
        var grounded = false;

        RaycastHit2D hit = Physics2D.Raycast(rigidbody.transform.position, Vector2.down, rayDistance, groundLayer);
        if (hit)
        {
            groundAngle = Vector2.Angle(hit.normal, Vector2.up);
            if (snap)
            {
                rigidbody.AddForce(Vector2.down, ForceMode2D.Impulse);
                grounded = true;
            }
        }

        return grounded;
    }

    public void Jump()
    {
        rigidbody.AddForce(new Vector2(0, config.JumpForce), ForceMode2D.Impulse);
    }

    private void Rotate(float horizontalInput)
    {
        Vector3 currentScale = rigidbody.transform.localScale;
        currentScale.x = horizontalInput;
        rigidbody.transform.localScale = currentScale;
    }
}
