using UnityEngine;

public class SpawnWithInput : MonoBehaviour
{
	public GameObject objectToSpawn;
	public float amountToSpawn = 1f;
	public float spawnDistance = 0f;
	public KeyCode spawnButton = KeyCode.Space;
	public bool spawnAsACircle = true;

	void Update()
	{
		if (Input.GetKeyDown(spawnButton))
			Spawn();
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
