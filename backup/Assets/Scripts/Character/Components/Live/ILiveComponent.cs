using System;

public interface ILiveComponent 
{
    public event Action OnDeath;

    public bool IsAlive { get; }

    public int MaxHealth { get; }

    public float Health { get; }

    public void GetDamage(float damage);
}
