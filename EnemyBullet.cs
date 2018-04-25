using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    public float bulletSpeed = 10;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * bulletSpeed * Time.deltaTime);
        if (transform.position.x < -8.5)
        {
            Destroy(this.gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (!other.GetComponent<PlayerControl>().isDeath)
            {
                other.gameObject.SendMessage("BeHit");
                GameObject.Destroy(this.gameObject);
            }
        }
    }
}
