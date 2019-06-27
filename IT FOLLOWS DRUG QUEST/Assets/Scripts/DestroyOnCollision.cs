using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyOnCollision : MonoBehaviour
{
	public string tagToCollideWith = "IT";
	public bool destroyThisObject = true;
	public bool destroyOtherObject = false;

	public void OnCollisionEnter2D(Collision2D collision)
	{
		Collide(collision.gameObject);
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		Collide(other.gameObject);	
	}

	public void Collide(GameObject otherObject)
	{
		if (tagToCollideWith != "IT" && otherObject.tag != tagToCollideWith)
			return;

		if (destroyOtherObject == true)
		{
			Destroy(otherObject);
			SceneManager.LoadScene("DeathScene");
		}

		if (destroyThisObject == true)
			Destroy(gameObject);
	}
}
