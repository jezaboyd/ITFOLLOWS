using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PS_BackgroundScroller : MonoBehaviour
{
    public float scrollSpeed = 1f;
    public float scrollOffset;
    private Vector2 startPos;
    private float newPos;

	
	void Start ()
    {
        startPos = transform.position;
	}
	
	
	void Update ()
    {
        newPos = Mathf.Repeat(Time.time * -scrollSpeed, scrollOffset);
        transform.position = startPos + Vector2.right * newPos;
	}
}
