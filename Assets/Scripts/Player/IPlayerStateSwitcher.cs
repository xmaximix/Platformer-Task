public interface IPlayerStateSwitcher 
{
    void SwitchState<T>() where T : BasePlayerState;
}
