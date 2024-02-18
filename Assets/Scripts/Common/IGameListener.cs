public interface IGameListener
{

}
public interface IStartListener: IGameListener
{
    void StartGame();
}
public interface IInitListener : IGameListener
{
    void OnInit();
}
public interface IDisableListener : IGameListener
{
    void Disable();
}
public interface IUpdateListener : IGameListener
{
    void Update();
}

public interface IFixedUpdateListener : IGameListener
{
    void FixedUpdate();
}
public interface IPausedListener : IGameListener
{
    void Pause();
}
public interface IUnPausedListener : IGameListener
{
    void UnPause();
}
