using System;
using UnityEngine;

public class EnemyLiveComponent : ILive
{
    private Character selfCharacter; 

    private float maxHealth;

    private float health;

    public float MaxHealth => maxHealth;

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

    public bool IsAlive => Health > 0;

    public event Action<Character> OnDeath;

    public event Action<Character> OnCharacterHealthChange;

    public void GetDamage(float damage)
    {
        Health -= damage;
        Debug.Log($"Enemy get damage = {damage}. Health = {Health}");
        OnCharacterHealthChange?.Invoke(selfCharacter);
    }

    public void Initialize(CharacterData characterData, Character selfCharacter)
    {
        health = characterData.Health;
        maxHealth = characterData.MaxHealth;
        this.selfCharacter = selfCharacter;
    }

    public void SetDeath()
    {
        OnDeath?.Invoke(selfCharacter);
    }

}
