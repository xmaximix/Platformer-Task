using Spine.Unity;
using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private SkeletonAnimation playerSpine;
    private PlayerAnimations animations;

    [SerializeField] private MovementConfig movementConfig;
    [HideInInspector] public Movement movement;

    private PlayerBehaviour playerBehaviour;

    public Action OnSlide;

    public void Initialize()
    {
        animations = new PlayerAnimations(playerSpine);

        var rigidbody = GetComponent<Rigidbody2D>();
        movement = new Movement(rigidbody, movementConfig);

        playerBehaviour = new PlayerBehaviour(this);
    }

    private void Update()
    {
        playerBehaviour.Update();
    }

    private void FixedUpdate()
    {
        playerBehaviour.FixedUpdate();
    }

    public void StartSliding()
    {
        animations.EnableSlideSlopeAnimation();
        OnSlide?.Invoke();
    }

    public void StartRunning()
    {
        animations.EnableRunAnimation();
    }

    public void StartIdle()
    {
        animations.EnableIdleAnimation();
    }

    public void StartJumping()
    {
        animations.EnableJumpAnimation();
    }
}
