using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Bullet : MonoBehaviour {
    public float bulletSpeed = 10;
    private GameObject player;
    private Transform target;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, target.position,  bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (!other.GetComponent<Enemy1Move>().isDeath)
            {
                other.gameObject.SendMessage("BeHit");
                GameObject.Destroy(this.gameObject);
            }
        }
    }
}

