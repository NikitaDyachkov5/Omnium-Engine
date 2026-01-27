using UnityEngine;

public class CharacterData : MonoBehaviour
{
    [SerializeField]
    private CharacterController characterController;

    [SerializeField]
    private Weapon weapons;

    [SerializeField]
    private Transform characterTransform;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float health;

    [SerializeField]
    private float maxHealth;

    [SerializeField]
    private int scoreCost;

    /// 

    public Weapon Weapons => weapons;

    public int ScoreCost => scoreCost;

    public float MaxHealth => maxHealth;

    public float Health => health;

    public float DefualtSpeed => speed;

    public CharacterController CharacterController => characterController;

    public Transform CharacterTransform => characterTransform;

}
