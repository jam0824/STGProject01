using UnityEngine;

public interface IFormation
{
    public void StartFormation(GameObject prefab, int numberOfObjects, float distanceBetweenObjects, float angle, float moveSpeed, float moveDir);
}
