using UnityEngine;

public class IdleState : BasePlayerState
{
    public IdleState(Player player, IPlayerStateSwitcher stateSwitcher) : base(player, stateSwitcher)
    {
    }

    public override void Enter()
    {
        player.StartIdle();
        player.movement.Move(0);
    }

    public override void Update()
    {
        if (player.movement.GroundAngle > 40)
        {
            stateSwitcher.SwitchState<SlopeSlideState>();
            return;
        }

        if (InputSystem.GetHorizontalRaw() != 0)
        {
            stateSwitcher.SwitchState<RunState>();
            return;
        }

        if (InputSystem.GetKeyDown(KeyCode.Space) && player.movement.GroundAngle <= 40)
        {
            stateSwitcher.SwitchState<JumpState>();
            return;
        }
    }

    public override void FixedUpdate()
    {
        player.movement.CheckGround();
    }
}
