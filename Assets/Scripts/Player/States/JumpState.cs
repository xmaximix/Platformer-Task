using UnityEngine;

public class JumpState : BasePlayerState
{
    public JumpState(Player player, IPlayerStateSwitcher stateSwitcher) : base(player, stateSwitcher)
    { 
    }

    public override void Enter()
    {
        player.StartJumping();
        player.movement.Jump();
    }

    public override void Update()
    {
        stateSwitcher.SwitchState<InAirState>();
    }
}
