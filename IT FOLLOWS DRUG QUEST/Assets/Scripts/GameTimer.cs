using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
	public Text timeText;

	float ellapsedTime;
    
    void Update()
    {
		ellapsedTime += Time.deltaTime;

		if (timeText != null)
			timeText.text = ellapsedTime.ToString("F0");
    }
}
