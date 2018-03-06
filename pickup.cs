using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth.maxHealth += 30;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
