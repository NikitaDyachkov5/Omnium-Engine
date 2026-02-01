using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Character
{
    public override Character CharacterTarget
    {
        get
        {
            Character target = null;
            float minDistance = characterData.Weapons.rangeAttack; // если не работает ставим float.MaxValue
            List<Character> list = GameManager.Instance.CharacterFactory.ActiveCharacters;

            for(int i = 0; i < list.Count; i++)
            {
                if (list[i].CharacterType == CharacterType.Player)
                    continue;

                float distanceBetween = Vector3.Distance(list[i].transform.position, transform.position);

                if (distanceBetween < minDistance)
                {
                    target = list[i];
                    minDistance = distanceBetween;
                }
            }
            return target;
        }
    }

    public override void Initialize()
    {
        base.Initialize();
        LiveComponent = new PlayerLiveComponent();
        LiveComponent.Initialize(characterData, this);

        AttackComponent = new CharacterAttackComponent();
        AttackComponent.Initialize(characterData);

        Input = new PlayerInput();
    }



    public override void Update()
    {
        if (!LiveComponent.IsAlive)
            return;

        Vector3 direction = Input.GetMoveDirection();

        if(CharacterTarget == null)
            MovableComponent.Rotation(direction);
        else
        {
            Vector3 rotationDirection = CharacterTarget.transform.position - transform.position;
            MovableComponent.Rotation(rotationDirection);
            AttackComponent.MakeDamage(CharacterTarget);
        }


        MovableComponent.Move(direction);
    }

    public Weapon SwitchWeapon(Weapon weapon)
    {
        return weapon;
    }
}
