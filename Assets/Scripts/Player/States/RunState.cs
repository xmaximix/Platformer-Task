using UnityEngine;

public class RunState : BasePlayerState
{
    private float horizontalInput;

    public RunState(Player player, IPlayerStateSwitcher stateSwitcher) : base(player, stateSwitcher)
    {
    }

    public override void Enter()
    {
        player.StartRunning();
    }

    public override void Update()
    {
        horizontalInput = InputSystem.GetHorizontalRaw();

        if (horizontalInput == 0)
        {
            stateSwitcher.SwitchState<IdleState>();
            return;
        }

        if (InputSystem.GetKeyDown(KeyCode.Space) && player.movement.GroundAngle <= 40)
        {
            stateSwitcher.SwitchState<JumpState>();
            return;
        }

        if (player.movement.GroundAngle > 40)
        {
            stateSwitcher.SwitchState<SlopeSlideState>();
            return;
        }
    }

    public override void FixedUpdate()
    {
        player.movement.Move(horizontalInput);
        player.movement.CheckGround();
    }
}
