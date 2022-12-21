using System.Collections.Generic;
using System.Linq;

public class PlayerBehaviour : IPlayerStateSwitcher
{
    private Player player;
    private BasePlayerState currentState;
    private List<BasePlayerState> allStates;

    public PlayerBehaviour(Player player)
    {
        this.player = player;
        Initialize();
    }

    private void Initialize()
    {
        allStates = new List<BasePlayerState>()
        {
            new IdleState(player, this),
            new RunState(player, this),
            new JumpState(player, this),
            new InAirState(player, this),
            new SlopeSlideState(player, this)
        };

        currentState = allStates[0];
        currentState.Enter();
    }

    public void Update()
    {
        currentState.Update();
    }

    public void FixedUpdate()
    {
        currentState.FixedUpdate();
    }

    public void SwitchState<T>() where T : BasePlayerState
    {
        var state = allStates.FirstOrDefault(s => s is T);
        currentState.Exit();
        state.Enter();
        currentState = state;
    }
}
