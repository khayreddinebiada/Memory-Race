using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPrototype : MonoBehaviour
{

    public bool waitAndDestroy = false;
    public float timeWaitingForDestroy = 15;

    private float currentTime;

	// Use this for initialization
	void Start () {
        // StartCoroutine(WaitAndDestroy());
	}
	
	// Update is called once per frame
	void Update () {
        if (Player.player.isMove && waitAndDestroy)
        {
            currentTime += Time.deltaTime;
            if (timeWaitingForDestroy <= currentTime)
            {
                Destroy(gameObject);
            }
        }
	}

    IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(timeWaitingForDestroy);

        Destroy(gameObject);
    }

}
