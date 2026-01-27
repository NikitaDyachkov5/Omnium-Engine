using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] protected CharacterData characterData;
    [SerializeField] private CharacterType characterType;

    public CharacterType CharacterType => CharacterType;

    /*
     OR
        public CharacterType CharacterType => characterType; check main
     */

    public CharacterData CharacterData => characterData;

    public virtual Character CharacterTarget { get; }

    public IMovable MovableComponent { get; protected set; }
    public ILiveComponent LiveComponent {  get; protected set; }
    public IAttackComponent AttackComponent { get; protected set; }

    public virtual void Initialize()
    {
        AttackComponent = new CharacterAttackComponent();
        AttackComponent.Initialize(characterData);
        MovableComponent = new CharacterMovementComponent();
        MovableComponent.Initialize(characterData);
    }

    public abstract void Update();
}
