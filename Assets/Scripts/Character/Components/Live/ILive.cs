using System;
using UnityEngine;

public interface ILive : ICharacter
{
   public event Action<Character> OnDeath;

   public event Action<Character> OnCharacterHealthChange;

   public bool IsAlive { get; }    
   
   public float MaxHealth { get; }

   public float Health { get; }

   public void GetDamage(float damage);

   public void SetDeath();
}
