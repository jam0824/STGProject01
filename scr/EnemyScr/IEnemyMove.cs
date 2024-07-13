using UnityEngine;

public interface IEnemyMove
{
    public void EnemyMove(Rigidbody rb, EnemyAnimation enemyAnimation, float angle, float speed, bool isMoveWithScroll);
}
