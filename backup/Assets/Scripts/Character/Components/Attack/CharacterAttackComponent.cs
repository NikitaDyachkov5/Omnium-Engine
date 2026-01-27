using UnityEngine;

public class CharacterAttackComponent : IAttackComponent
{
    private float lockDamageTime = 2;

    public float Damage => 5;

    private Transform characterTransform;

    public void Initialize(CharacterData characterData)
    {
        characterTransform = characterData.CharacterTransform;
    }

    public void MakeDamage(Character target)
    {
        if (target == null)
            return;

        if(!target.LiveComponent.IsAlive)
            return;

        if (Vector3.Distance(target.transform.position, characterTransform.position) > 3)
            return;

        if (lockDamageTime > 0)
        {
            lockDamageTime -= Time.deltaTime;
            return;
        }

        target.LiveComponent.GetDamage(Damage);

        lockDamageTime = 1;
    }


}
