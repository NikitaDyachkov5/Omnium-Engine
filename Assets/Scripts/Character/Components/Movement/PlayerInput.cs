using UnityEngine;

public class PlayerInput : ICharacterInput
{
    public Vector3 GetMoveDirection()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        return new Vector3(moveHorizontal, 0, moveVertical).normalized;
    }
}
