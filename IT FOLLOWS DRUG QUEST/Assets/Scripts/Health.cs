using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
	public int health = 5;
	public bool dieAtHealthZero = false;
	public Text healthText;
	public UnityEvent onHealthZero;

	public void LoseHealth()
	{
		if (health <= 0)
			return;

		health--;

		if (health <= 0)
		{
			onHealthZero.Invoke();
			if (dieAtHealthZero)
				Destroy(gameObject);
		}

		if (healthText != null)
			healthText.text = health.ToString();
	}
}
