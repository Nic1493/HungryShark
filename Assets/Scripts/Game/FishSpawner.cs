using System.Collections;
using UnityEngine;
using static CoroutineHelper;

public class FishSpawner : MonoBehaviour
{
    Shark shark;

    [SerializeField] Transform fishParentTransform;
    [SerializeField] GameObject[] fishPrefabs = new GameObject[2];

    // time to wait in between spawning fish;
    float spawnDelay = 2f;
    const float minSpawnDelay = 0.5f;

    // % chance to spawn pufferfish instead of regular fish
    float pufferfishSpawnRate = 0.1f;
    const float maxPufferfishSpawnRate = 0.4f;

    void Awake()
    {
        shark = FindObjectOfType<Shark>();
        shark.DeathAction += OnPlayerDie;
    }

    IEnumerator Start()
    {
        while (enabled)
        {
            for (int i = 0; i < 20; i++)
            {
                int randIndex = Random.value > pufferfishSpawnRate ? 0 : 1;
                GameObject newFish = Instantiate(fishPrefabs[randIndex], fishParentTransform);

                newFish.transform.position = new Vector3(fishParentTransform.position.x, Random.Range(-3f, 4f));

                yield return WaitForSeconds(spawnDelay);
            }

            // increase difficulty after spawning every 20 fish
            IncreaseDifficulty();
        }
    }

    // decrease wait time between spawning fish by 0.1sec., and
    // increase pufferfish spawn rate by 5%
    void IncreaseDifficulty()
    {
        spawnDelay = Mathf.Max(spawnDelay - 0.1f, minSpawnDelay);
        pufferfishSpawnRate = Mathf.Min(pufferfishSpawnRate + 0.05f, maxPufferfishSpawnRate);
    }

    void OnPlayerDie()
    {
        enabled = false;
    }
}