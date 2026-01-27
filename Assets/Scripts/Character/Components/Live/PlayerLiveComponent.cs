using System;
using UnityEngine;

public class PlayerLiveComponent : ILive
{
    private Character selfCharacter;

    private float health;

    private float maxHealth;

    public float MaxHealth => maxHealth;

    public bool IsAlive => Health > 0;

    public float Health
    {
        get => health;
        private set
        {
            health = value;
            if(health <= 0)
            {
                health = 0;
                SetDeath();
            }
        }
    }

    public event Action<Character> OnDeath;

    public void GetDamage(float damage)
    {
        Health -= damage;
        Debug.Log($"Player get damage = {damage}. Health = {Health}");
    }

    public void Initialize(CharacterData characterData, Character selfCharacter)
    {
        health = characterData.Health;
        maxHealth = characterData.MaxHealth;
        this.selfCharacter = selfCharacter;
        Debug.Log($"Player Health = {Health}");
    }

    public void SetDeath()
    {
        OnDeath?.Invoke(selfCharacter);
    }

}
