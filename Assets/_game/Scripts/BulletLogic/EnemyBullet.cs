using UnityEngine;

public class EnemyBullet : Bullet, IInteractable
{
    public override void Update()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);
    }
}