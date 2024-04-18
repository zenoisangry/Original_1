using UnityEngine;

public interface IDamageable
{
    void Start();
    void TakeHit(float damage, RaycastHit hit);
}