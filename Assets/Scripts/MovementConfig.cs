using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MovementConfig")]
public class MovementConfig : ScriptableObject
{
    [SerializeField] private float movementSpeed = 4f;
    public float MovementSpeed => movementSpeed;

    [SerializeField] private float jumpForce = 2f;
    public float JumpForce => jumpForce;

    [SerializeField] private float maxSlopeAngle = 30f;
    public float MaxSlopeAngle => maxSlopeAngle;
}
