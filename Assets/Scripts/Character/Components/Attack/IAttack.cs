using UnityEngine;

public interface IAttack 
{

    public void Initialize(CharacterData characterData);

    public void MakeDamage(Character target);
}
