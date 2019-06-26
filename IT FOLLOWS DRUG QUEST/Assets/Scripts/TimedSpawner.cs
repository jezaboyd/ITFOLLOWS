using UnityEngine;

public class TimedSpawner : MonoBehaviour
{
	public GameObject objectToSpawn;
	public float spawnCooldown = 1f;
	public float amountToSpawn = 1f;
	public float spawnDistance = 0f;
	public bool spawnAsACircle = true;

    void Start()
    {
		InvokeRepeating("Spawn", spawnCooldown, spawnCooldown);    
    }

	void Spawn()
	{
		int amountSpawned = 0;
		while (amountSpawned < amountToSpawn)
		{
			Vector3 offset = Vector3.zero;

			if (spawnAsACircle)
				offset = Random.insideUnitCircle * spawnDistance;
			else
				offset.x = Random.Range(-spawnDistance, spawnDistance);

			Instantiate(objectToSpawn, transform.position + offset, transform.rotation);

			amountSpawned++;
		}
	}
}
