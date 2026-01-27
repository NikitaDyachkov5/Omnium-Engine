using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Weapon")]
public class Weapon : ScriptableObject
{
    [SerializeField]
    public string name;

    [SerializeField]
    public  string discription;

    [SerializeField]
    public  float damage;

    [SerializeField]
    public  float rangeAttack;

    [SerializeField]
    public  float cooldown;
}
