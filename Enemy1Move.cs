using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Move : MonoBehaviour
{
    public int hp = 10;

    public float speed = 5;

    public bool isDeath = false;

    private float deadTimer = 0;

    public float attackTimer = 0;

    public float attackRate = 1f;

    private int score = 10;

    private Animator animator;

    public GameObject enemy1Bullet;
    private AudioSource _audio;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer += Time.deltaTime;
        this.transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (attackTimer >= attackRate)
        {
            Enemy1Attack();
            attackTimer = 0;
        }
        if (this.transform.position.x <= -10f)
        {
            Destroy(this.gameObject);
        }
        if (isDeath)
        {
            animator.SetTrigger("Dead");
            deadTimer += Time.deltaTime;
            if (deadTimer >= 0.334)
            {
                GameObject.Destroy(this.gameObject);
            }           
        }
    }

    public void Enemy1Attack()
    {
        animator.SetTrigger("Attack");
        GameObject.Instantiate(enemy1Bullet, transform.position, Quaternion.identity);
    }

    public void BeHit()
    {
        _audio.Play();
        hp -= 1;
        if (hp <= 0)
        {
            toDie();
        }
    }

    private void toDie()
    {
        if (!isDeath)
        {
            isDeath = true;
            GameManager._instance.score += score;
        }
    }

}