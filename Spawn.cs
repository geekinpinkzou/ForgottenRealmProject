using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
    public GameObject enemy1;
    public GameObject enemy2;

    public float enemy1Rate = 5f;
    public float enemy2Rate = 7f;

	// Use this for initialization
	void Start () {
        InvokeRepeating("CreatEnemy1", 1, enemy1Rate);
        InvokeRepeating("CreatEnemy2", 1, enemy2Rate);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CreatEnemy1()
    {
        float y = Random.Range(-2.8f,3.5f);
        GameObject.Instantiate(enemy1, new Vector3(transform.position.x,y,transform.position.z), Quaternion.identity);
    }
    public void CreatEnemy2()
    {
        float y = Random.Range(-2.9f, 3.5f);
        GameObject.Instantiate(enemy2, new Vector3(transform.position.x, y, transform.position.z), Quaternion.identity);
    }
}
