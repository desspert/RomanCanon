﻿using UnityEngine;
using System.Collections;

public class test2 : MonoBehaviour {

    private Vector3 player;

    public float speed = 1.0f;

	void Start ()
    {
        player = new Vector3(0.0f, 0.0f, 0.0f);
	}
	
	void Update ()
    {
        Quaternion targetRotation = Quaternion.LookRotation(player - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 1.0f);

        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        float e_p_dis = Vector3.SqrMagnitude(transform.position - player);

        if (e_p_dis < 10.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
