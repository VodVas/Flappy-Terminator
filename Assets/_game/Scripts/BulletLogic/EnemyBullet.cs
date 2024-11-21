using UnityEngine;

public class EnemyBullet : Bullet, IInteractable
{
    private void Update()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);
    }
}