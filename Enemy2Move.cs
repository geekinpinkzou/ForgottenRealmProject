using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Move : MonoBehaviour
{
    public int hp = 20;

    public float speed = 5;

    public bool isDeath = false;

    private float deadTimer = 0;

    public float moveTimer = 0;

    public float attackTimer = 0;

    public float attackRate = 1f;

    private int score = 20;

    private Animator animator;

    private GameObject player;

    public GameObject enemy2Bullet;

    private AudioSource _audio;


    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        _audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 5.5f || moveTimer >= 20)
        {
            this.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        else if (transform.position.x <= 5.5f)
        {
            moveTimer += Time.deltaTime;
            attackTimer += Time.deltaTime;
            float toss = Random.Range(-2,2);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, player.transform.position.y, transform.position.z), 0.5f * (speed+toss) * Time.deltaTime);
            if (attackTimer >= attackRate)
            {
                Enemy2Attack();
                attackTimer = 0;
            }
        }

        if (this.transform.position.x <= -10f)
        {
            Destroy(this.gameObject);
        }
        
        if (isDeath)
        {
            animator.SetTrigger("Dead");
            deadTimer += Time.deltaTime;
            if (deadTimer >= 0.5)
            {
                GameObject.Destroy(this.gameObject);
            }
        }
    }

    public void Enemy2Attack()
    {
        animator.SetTrigger("Attack");
        GameObject.Instantiate(enemy2Bullet, new Vector3(transform.position.x-1f, transform.position.y, transform.position.z), Quaternion.identity);
    }

    public void BeHit()
    {
        hp -= 1;
        _audio.Play();
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