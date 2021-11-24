using UnityEngine;

public class Pufferfish : Fish
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Shark shark))
        {
            hitbox.enabled = false;
            shark.LoseLifeAction?.Invoke();
        }
    }
}