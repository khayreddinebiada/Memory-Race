using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    public float rotateSpeed = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(rotateSpeed * Vector3.up * Time.deltaTime);
	}


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            ControlUI.controlUI.AddCoin();
            AudioManager.audioManager.IsAddCoins();

            Destroy(gameObject);
        }
    }
}
