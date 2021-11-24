using UnityEngine;

public class Shark : Actor
{
    Camera mainCam;

    [SerializeField] IntObject score;

    public delegate void IncreaseScoreDelegate(int amount);
    public IncreaseScoreDelegate IncreaseScoreAction;

    public event System.Action GameOverAction;

    protected override void Awake()
    {
        base.Awake();
        mainCam = Camera.main;

        score.value = 0;
        IncreaseScoreAction += IncreaseScore;
        GameOverAction += OnGameOver;
    }

    // handle movement through mouse input
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10f;

            Vector3 newPos = mainCam.ScreenToWorldPoint(mousePos);
            transform.position = Vector3.SmoothDamp(transform.position, newPos, ref moveDirection, 0.1f);
        }
    }

    protected override void Die()
    {
        GameOverAction?.Invoke();
    }

    void IncreaseScore(int amount)
    {
        score.value += amount;
    }

    void OnGameOver()
    {
        enabled = false;
    }
}