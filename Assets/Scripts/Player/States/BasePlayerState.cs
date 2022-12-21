public abstract class BasePlayerState 
{
    protected readonly Player player;
    protected readonly IPlayerStateSwitcher stateSwitcher;

    protected BasePlayerState(Player player, IPlayerStateSwitcher stateSwitcher)
    {
        this.player = player;
        this.stateSwitcher = stateSwitcher;
    }

    public virtual void Enter()
    {

    }

    public virtual void Update()
    {

    }

    public virtual void FixedUpdate()
    {

    }

    public virtual void Exit()
    {

    }
}
