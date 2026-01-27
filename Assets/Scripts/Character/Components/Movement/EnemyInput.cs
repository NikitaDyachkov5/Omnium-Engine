using UnityEngine;

public class EnemyInput : ICharacterInput
{
    private Vector3 direction;

    public void SetDirection(Vector3 dir)
    {
        direction = dir;
    }

    public Vector3 GetMoveDirection()
    {
        return direction;
    }
}
