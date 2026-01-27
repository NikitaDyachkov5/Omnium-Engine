using UnityEngine;

public class EnemyCharacter : Character
{
    [SerializeField] private AiState aistate;
    [SerializeField] private Character characterTarget;

    [SerializeField] public override Character CharacterTarget => GameManager.Instance.CharacterFactory.Player;

    public override void Initialize()
    {
        base.Initialize();

        LiveComponent = new EnemyLiveComponent();

    }

    public override void Update()
    {
        switch (aistate)
        {
            case AiState.None:

                break;

            case AiState.MoveToTarget:
                Vector3 direction = CharacterTarget.transform.position - transform.position;
                direction.Normalize();
                Move();
                AttackComponent.MakeDamage(CharacterTarget);
                break;

            default:
                return;
        }
    }
    //public override void Update()
    //{
    //    switch (aistate)
    //    {
    //        case AiState.None:

    //            break;

    //        case AiState.MoveToTarget:
    //            Vector3 direction = CharacterTarget.transform.position - transform.position;
    //            direction.Normalize();

    //MovableComponent.Move(direction);
    //            MovableComponent.Rotation(direction);

    //            if(Vector3.Distance(CharacterTarget.transform.position, transform.position) < 3 )
    //            {
    //                AttackComponent.MakeDamage(CharacterTarget);
    //            }

    //            break;

    //        default:
    //            return;
    //    }
    //}


    private void Move()
    {
        if (CharacterTarget == null)
            return;

        Vector3 direction = (CharacterTarget.transform.position - characterData.CharacterTransform.position).normalized;

        MovableComponent.Move(direction);
        MovableComponent.Rotation(direction);
    }
}
