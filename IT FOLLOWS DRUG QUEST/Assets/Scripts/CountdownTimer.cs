using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
	public float countdownTime = 30f;
	public Text timerText;
	public UnityEvent onTimeEnd;

	bool triggered = false;

	void Update()
	{
		countdownTime -= Time.deltaTime;

		if (timerText != null)
			timerText.text = countdownTime.ToString("F0");

		if (countdownTime <= 0f && triggered == false)
		{
			triggered = true;

			onTimeEnd.Invoke();
		}
	}
}
