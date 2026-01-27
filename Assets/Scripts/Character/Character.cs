using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField]
    private CharacterType characterType;

    [SerializeField]
    protected CharacterData characterData;

    public IMovable MovableComponent { get; protected set; }
    public ILive LiveComponent { get; protected set; }
    public IAttack AttackComponent { get; protected set; }
    public ICharacterInput Input {  get; protected set; }

    public CharacterData CharacterData => characterData;

    public CharacterType CharacterType => characterType;

    public virtual Character CharacterTarget { get; }


    public virtual void Initialize()
    {
        MovableComponent = new CharacterMovementComponent();
        MovableComponent.Initialize(characterData);
    }

    public abstract void Update();
}
