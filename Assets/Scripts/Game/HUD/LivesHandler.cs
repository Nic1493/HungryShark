using UnityEngine;
using UnityEngine.UI;

public class LivesHandler : MonoBehaviour
{
    Image[] lifeIcons;

    void Awake()
    {
        lifeIcons = GetComponentsInChildren<Image>();
        FindObjectOfType<Shark>().LoseLifeAction += OnLoseLife;
    }

    void OnLoseLife()
    {
        for (int i = lifeIcons.Length - 1; i >= 0; i--)
        {
            if (lifeIcons[i].enabled)
            {
                lifeIcons[i].enabled = false;
                break;
            }
        }
    }
}