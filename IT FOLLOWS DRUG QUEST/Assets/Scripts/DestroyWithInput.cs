using UnityEngine;

public class DestroyWithInput : MonoBehaviour
{
	public KeyCode destructionButton = KeyCode.X;

    void Update()
    {
		if (Input.GetKeyDown(destructionButton))
			Destroy(gameObject);
    }
}
