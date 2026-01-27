using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float speed;
    [SerializeField] private int scoreCost;
    [SerializeField] private Transform characterTransform;

    public CharacterController CharacterController => characterController;
    public float DefaultSpeed => speed;
    public int ScoreCost => scoreCost;
    public Transform CharacterTransform => characterTransform;
}
