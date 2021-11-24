using UnityEngine;

public class Pufferfish : Fish
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        hitbox.enabled = false;

        if (other.TryGetComponent(out Shark shark))
        {
            shark.LoseLifeAction?.Invoke();
        }
    }
}