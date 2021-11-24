using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public abstract class Actor : MonoBehaviour
{
    [HideInInspector]
    new public Transform transform;
    protected Collider2D hitbox;
    protected SpriteRenderer spriteRenderer;

    public delegate void LoseLifeDelegate();
    public LoseLifeDelegate LoseLifeAction;

    public event System.Action DeathAction;

    [SerializeField]
    int maxLives;
    int currentLives;

    protected Vector3 moveDirection;

    protected virtual void Awake()
    {
        // init. components
        transform = GetComponent<Transform>();
        hitbox = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // subscribe functions to events
        LoseLifeAction += LoseLife;
        DeathAction += Die;

        // init. stats
        currentLives = maxLives;
    }

    protected virtual void LoseLife()
    {
        currentLives--;

        if (currentLives <= 0)
        {
            DeathAction?.Invoke();
        }
    }

    protected abstract void Die();
}