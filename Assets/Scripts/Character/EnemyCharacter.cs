using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyCharacter : Character
{
    [SerializeField]
    private AiState aiState;

    public override Character CharacterTarget => GameManager.Instance.CharacterFactory.Player;

    public override void Initialize()
    {
        base.Initialize();
        LiveComponent = new EnemyLiveComponent();
        LiveComponent.Initialize(characterData, this);
        AttackComponent = new CharacterAttackComponent();
        AttackComponent.Initialize(characterData);

        Input = new EnemyInput();

    }

    public override void Update()
    {
        if (!LiveComponent.IsAlive) return;

        Vector3 direction = Input.GetMoveDirection();

        MovableComponent.Move(direction);
        MovableComponent.Rotation(direction);

        UpdateAI();

    }

    private void UpdateAI()
    {

        if (CharacterTarget == null)
            return;

        float distance = Vector3.Distance(CharacterTarget.transform.position, characterData.CharacterTransform.position);

        switch (aiState)
        {
            case AiState.None:
                aiState = AiState.MoveToTarget;
                break;

            case AiState.MoveToTarget:
                if (distance > characterData.Weapons.rangeAttack)
                {
                    Vector3 dir =
                        (CharacterTarget.transform.position -
                         characterData.CharacterTransform.position).normalized;

                    ((EnemyInput)Input).SetDirection(dir);
                }
                else
                {
                    ((EnemyInput)Input).SetDirection(Vector3.zero);
                    aiState = AiState.Attack;
                }
                break;

            case AiState.Attack:
                ((EnemyInput)Input).SetDirection(Vector3.zero);
                AttackComponent.MakeDamage(CharacterTarget);

                if (distance > characterData.Weapons.rangeAttack)
                    aiState = AiState.MoveToTarget;
                break;
        }

    }
}


// Engine #3 1:14:00 backup work
/*
 using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyCharacter : Character
{
    [SerializeField]
    private Character targetCharacter;

    [SerializeField]
    private AiState aiState;

    public override void Initialize()
    {
        base.Initialize();
        LiveComponent = new EnemyLiveComponent();
        LiveComponent.Initialize(characterData);
        AttackComponent = new CharacterAttackComponent();
        AttackComponent.Initialize(characterData);

        Input = new EnemyInput();

        //CharacterData data = GetComponent<CharacterData>(); // эти строки не желательны

        //if(targetCharacter == null)
        //    targetCharacter = GameObject.FindObjectOfType<PlayerCharacter>();
    }

    public override void Update()
    {
        if (!LiveComponent.IsAlive) return;

        Vector3 direction = Input.GetMoveDirection();

        MovableComponent.Move(direction);
        MovableComponent.Rotation(direction);

        UpdateAI();


    }

    private void UpdateAI()
    {

        if (targetCharacter == null)
            return;

        float distance = Vector3.Distance(targetCharacter.transform.position, characterData.CharacterTransform.position);

        switch (aiState)
        {
            case AiState.None:
                aiState = AiState.MoveToTarget;
                break;

            case AiState.MoveToTarget:
                if (distance > characterData.RangeAttack)
                {
                    Vector3 dir =
                        (targetCharacter.transform.position -
                         characterData.CharacterTransform.position).normalized;

                    ((EnemyInput)Input).SetDirection(dir);
                }
                else
                {
                    ((EnemyInput)Input).SetDirection(Vector3.zero);
                    aiState = AiState.Attack;
                }
                break;

            case AiState.Attack:
                ((EnemyInput)Input).SetDirection(Vector3.zero);
                AttackComponent.MakeDamage(targetCharacter);

                if (distance > characterData.RangeAttack)
                    aiState = AiState.MoveToTarget;
                break;
        }

    }
}

 */