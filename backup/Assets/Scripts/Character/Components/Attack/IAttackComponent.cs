public interface IAttackComponent
{
    public float Damage { get; }

    public void Initialize(CharacterData characterData);

    public void MakeDamage(Character target);
}
