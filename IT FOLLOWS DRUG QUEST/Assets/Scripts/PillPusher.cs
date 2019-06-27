using System;
using System.Collections;
using UnityEngine;

public class PillPusher : MonoBehaviour
{
    private static PillPusher s_Pusher;
    public GameObject[] pills;
    public float respawnDelay = 30.0f;

    private void Start()
    {
        s_Pusher = this;
    }

    private void OnDestroy()
    {
        s_Pusher = null;
    }

    public static void PushPill(Vector3 position)
    {
        if (s_Pusher)
        {
            s_Pusher.StartCoroutine(s_Pusher.DoPushPill(s_Pusher.respawnDelay, position));
        }
    }

    public IEnumerator DoPushPill(float delay, Vector3 position)
    {
        yield return new WaitForSeconds(delay);

        var index = UnityEngine.Random.Range(0, pills.Length);        
        
        if (pills[index])
        {
            var go = GameObject.Instantiate(pills[index]);
            go.transform.position = position;
        }
    }
}
