using UnityEngine;

public class Shark : Actor
{
    Camera mainCam;

    public event System.Action GameOverAction;

    protected override void Awake()
    {
        base.Awake();
        mainCam = Camera.main;

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

    void OnGameOver()
    {
        enabled = false;
    }
}