using UnityEngine;

public class CharacterAttackComponent : IAttack
{
    private Transform characterTransform;

    private Weapon weapon;


    public void Initialize(CharacterData characterData)
    {
        characterTransform = characterData.CharacterTransform;
        weapon = characterData.Weapons;
    }

    private float GetFinalDamage()
    {
        return weapon.damage;
    }

    public void MakeDamage(Character target)
    {
        if (target == null || !target.LiveComponent.IsAlive)
            return;

        if (Vector3.Distance(target.transform.position, characterTransform.position) > weapon.rangeAttack)
            return; 

        if(weapon.cooldown > 0)
        {
            weapon.cooldown -= Time.deltaTime;
            return;
        }

        target.LiveComponent.GetDamage(GetFinalDamage());
        weapon.cooldown = 1;
    }
}
