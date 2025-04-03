using UnityEngine;

/// <summary>
/// Spawns animals via key press and allows them to begin walking using their AI.
/// </summary>
public class AllAnimalsSpawner : MonoBehaviour
{
    public Transform spawnPoint;

    public GameObject alligatorPrefab;
    public GameObject rabbitPrefab;
    public GameObject catPrefab;
    public GameObject opossumPrefab;
    public GameObject heronPrefab;
    public GameObject egretPrefab;
    public GameObject frogPrefab;
    public GameObject pythonPrefab;

    private GameObject spawnedAnimal;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) SpawnAnimal(alligatorPrefab);
        if (Input.GetKeyDown(KeyCode.Alpha2)) SpawnAnimal(rabbitPrefab);
        if (Input.GetKeyDown(KeyCode.Alpha3)) SpawnAnimal(catPrefab);
        if (Input.GetKeyDown(KeyCode.Alpha4)) SpawnAnimal(opossumPrefab);
        if (Input.GetKeyDown(KeyCode.Alpha5)) SpawnAnimal(heronPrefab);
        if (Input.GetKeyDown(KeyCode.Alpha6)) SpawnAnimal(egretPrefab);
        if (Input.GetKeyDown(KeyCode.Alpha7)) SpawnAnimal(frogPrefab);
        if (Input.GetKeyDown(KeyCode.Alpha8)) SpawnAnimal(pythonPrefab);
    }

    /// <summary>
    /// Spawns an animal prefab at the spawn point and lets it walk via AI.
    /// </summary>
    void SpawnAnimal(GameObject animalPrefab)
    {
        if (animalPrefab == null)
        {
            Debug.LogError("No prefab assigned for this animal!");
            return;
        }

        if (spawnedAnimal != null)
        {
            Destroy(spawnedAnimal);
        }

        spawnedAnimal = Instantiate(animalPrefab, spawnPoint.position, Quaternion.identity);

        AnimalAI ai = spawnedAnimal.GetComponent<AnimalAI>();
        if (ai != null)
        {
            ai.ResumeWalking(); // start walking
        }
    }
}