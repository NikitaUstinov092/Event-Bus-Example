using System.Atomic.Implementations;

public sealed class TeamComponent
{
    public int GetTeam() => _team.Value;
    
    private readonly AtomicVariable<int> _team;
        
    public TeamComponent(AtomicVariable<int> team)
    {
        _team = team;
    }
}
