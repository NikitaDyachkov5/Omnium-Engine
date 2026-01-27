using System;

public class EnemyLiveComponent : ILiveComponent
{
    public bool IsAlive => Health > 0;

    public int MaxHealth => 10;

    private float health;

    public float Health
    {
        get => health;
        private set
        {
            health = value;
            if (health <= 0)
            {
                OnDeath?.Invoke();
            }
        }
    }

    public event Action OnDeath;

    public void GetDamage(float damage)
    {
        Health -= damage * 1000;
    }

}
