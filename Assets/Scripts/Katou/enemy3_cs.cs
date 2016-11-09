﻿using UnityEngine;
using System.Collections;

public class enemy3_cs : MonoBehaviour
{

    private Vector3 player;

    [SerializeField]
    private float speed = 2.0f;

    [SerializeField]
    private int add_score = 30;

    enemy_state state;

    [SerializeField]
    private int maxhp = 10;

    public int MaxHp
    {
        get { return maxhp; }
        set { maxhp = value; }
    }

    void Start()
    {
        player = GameObject.Find("Spawner").GetComponent<spawner_cs>().playerPos;
        state = GetComponent<enemy_state>();
        state.Hp = maxhp;
        //Debug.Log(state.Hp);
    }

    void Update()
    {
        if (state.isDed) return;

        float e_p_dis = Vector3.SqrMagnitude(transform.position - player);

        //if (e_p_dis < 10.0f)
        //{
        //    Attack();
        //}
        //else
        {
            Move();
        }
    }

    void Move()
    {
        Quaternion targetRotation = Quaternion.LookRotation(player - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 1.0f);

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void Attack()
    {

    }

}
