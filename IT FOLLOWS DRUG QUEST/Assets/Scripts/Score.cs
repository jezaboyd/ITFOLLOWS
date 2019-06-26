using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
	public int score;
	public int scoreThreshold;
	public Text scoreText;
	public UnityEvent onThresholdMet;

	bool triggered;

	public void AddScore()
	{
		score++;

		if (score >= scoreThreshold && triggered == false)
		{
			triggered = true;
			onThresholdMet.Invoke();
		}

		if (scoreText != null)
			scoreText.text = score.ToString();
	}
}

