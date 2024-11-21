using System;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    public event Action<IInteractable> Collided;

    private void OnValidate()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out IInteractable interactable))
        {
            Collided?.Invoke(interactable);
        }
    }
}