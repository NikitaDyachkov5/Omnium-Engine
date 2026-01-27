using System;
using UnityEngine;

public class PlayerLiveComponent : ILiveComponent
{
    private float health = 50;

    public int MaxHealth => 50;

    public event Action OnDeath;

    public bool IsAlive => health > 0;

    public float Health
    {
        get => health;
        private set
        {
            health = value;
            if (health <= 0)
            {
                health = 0;
                SetDeath();
            }
        }
    }


    public void GetDamage(float damage)
    {
        Health -= damage;
        Debug.Log($"Player make a damage ({damage}). Health ({Health})");
    }

    private void SetDeath()
    {
        OnDeath?.Invoke();
    }
   
}
