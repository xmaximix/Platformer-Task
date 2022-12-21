
using UnityEngine;

public class InAirState : BasePlayerState
{
    private float groundCheckDelay;
    private float horizontalInput;

    public InAirState(Player player, IPlayerStateSwitcher stateSwitcher) : base(player, stateSwitcher)
    {
    }

    public override void Enter()
    {
        groundCheckDelay = .9f;
    }

    public override void Update()
    {
        horizontalInput = InputSystem.GetHorizontalRaw();

        groundCheckDelay -= Time.deltaTime;
    }

    public override void FixedUpdate()
    {
        player.movement.Move(horizontalInput);
        if (groundCheckDelay <= 0 && player.movement.CheckGround())
        {
            stateSwitcher.SwitchState<IdleState>();
        }
    }
}
