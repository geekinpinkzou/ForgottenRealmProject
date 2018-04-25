using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {

    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode attackKey;
    private float speed = 5;

    private Animator animator;


    private Rigidbody2D body2D;

    public static int hp = 10;
    public bool isDeath = false;
    private AudioSource _audio;

    // Use this for initialization
    void Start () {
        body2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.identity;
        //控制玩家移动
        body2D.velocity = new Vector2(-2, 0);
        if (Input.GetKey(upKey))
        {
            body2D.velocity = new Vector2(-2, speed);
        }
        if (Input.GetKey(downKey))
        {
            body2D.velocity = new Vector2(-2, -speed);
        }
        if (Input.GetKey(leftKey))
        {
            body2D.velocity = new Vector2(-speed, 0);
        }
        if (Input.GetKey(rightKey))
        {
            body2D.velocity = new Vector2(speed-2, 0);
        }
        if (Input.GetKey(rightKey) && Input.GetKey(upKey))
        {
            body2D.velocity = new Vector2(speed-2, speed);
        }
        if (Input.GetKey(leftKey) && Input.GetKey(upKey))
        {
            body2D.velocity = new Vector2(-speed, speed);
        }
        if (Input.GetKey(leftKey) && Input.GetKey(downKey))
        {
            body2D.velocity = new Vector2(-speed, -speed);
        }
        if (Input.GetKey(rightKey) && Input.GetKey(downKey))
        {
            body2D.velocity = new Vector2(speed-2, -speed);
        }

        //控制玩家攻击
        if (Input.GetKey(attackKey))
        {
            animator.SetTrigger("Attack");
            //调用子弹和伤害的函数
        }


    }
    public void BeHit()
    {
        _audio.Play();
        hp -= 1;
        if (hp <= 0)
        {
            isDeath = true;
        }
    }

    private void toDie()
    {
        if (!isDeath)
        {
            isDeath = true;
            //游戏结束
        }
    }
}
