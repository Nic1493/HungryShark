using UnityEngine;

public class Fish : Actor
{
    [SerializeField] Sprite[] fishSprites;
    [SerializeField] Sprite[] deadFishSprites;

    int fishIndex;
    float moveSpeed;

    protected override void Awake()
    {
        base.Awake();

        // randomize sprite
        fishIndex = Random.Range(0, fishSprites.Length);
        spriteRenderer.sprite = fishSprites[fishIndex];

        // randomize movement speed
        moveSpeed = Random.Range(2f, 4f);

        // init. move direction
        moveDirection = Vector3.left;
    }

    // handle movement
    void Update()
    {
        transform.Translate(moveSpeed * Time.deltaTime * moveDirection.normalized);
    }

    // handle collision with Shark
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Shark shark))
        {
            hitbox.enabled = false;
            LoseLifeAction?.Invoke();

            shark.IncreaseScoreAction?.Invoke(100);
        }
    }

    // handle death events
    protected override void Die()
    {
        spriteRenderer.sprite = deadFishSprites[fishIndex];

        moveSpeed = 1f;
        spriteRenderer.flipY = true;
        moveDirection = Vector3.up;


    }

    void OnBecameInvisible()
    {
        Destroy(gameObject, 1f);
    }
}