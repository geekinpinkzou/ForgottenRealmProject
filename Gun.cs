using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public KeyCode attackKey;
    public float restTime = 1;
    public float restTimer = 0;

    public GameObject bullet;

    // Use this for initialization
	void Start () {
		
	}

    public void Fire() {
        GameObject.Instantiate(bullet, transform.position, Quaternion.identity);   
    }

	// Update is called once per frame
	void Update () {
        restTimer += Time.deltaTime;
        if (restTimer < restTime) return; 

        if (Input.GetKey(attackKey))
        {
            Fire();
        }

        restTimer = 0;
	}
}
