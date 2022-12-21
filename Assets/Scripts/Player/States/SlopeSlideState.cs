public class SlopeSlideState : BasePlayerState
{
    public SlopeSlideState(Player player, IPlayerStateSwitcher stateSwitcher) : base(player, stateSwitcher)
    {
    }

    public override void Enter()
    {
        player.StartSliding();
    }

    public override void Update()
    {
        if (player.movement.GroundAngle < 40)
        {
            stateSwitcher.SwitchState<IdleState>();
        }
    }

    public override void FixedUpdate()
    {
        player.movement.CheckGround();
    }
}
