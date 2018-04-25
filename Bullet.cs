 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float bulletSpeed = 10;
    private AudioSource _audio;
    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update () {
        //transform.position = new Vector3(transform.position.x+bulletSpeed*Time.deltaTime, transform.position.y, transform.position.z) ;
        transform.Translate(Vector3.right*bulletSpeed*Time.deltaTime);
        if (transform.position.x > 8.5)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy1")
        {
            if (!other.GetComponent<Enemy1Move>().isDeath)
            {
                other.gameObject.SendMessage("BeHit");
                GameObject.Destroy(this.gameObject);
            }
        }
        if (other.tag == "Enemy2")
        {
            if (!other.GetComponent<Enemy2Move>().isDeath)
            {
                other.gameObject.SendMessage("BeHit");
                GameObject.Destroy(this.gameObject);
            }
        }
    }

}
