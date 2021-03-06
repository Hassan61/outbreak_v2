﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spieler_Geschoss_Pre : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float distance;
    public int damage_zombie_kopf;
    public int damage_zombie_bauch;
    public int damage_hand;
    public LayerMask whatIsSolid;
    private Zombie_Leben z_zombie_leben;
    public GameObject destroyEffect;
    private Zombie_Boss_Leben z_zombie_boss_leben;
    public int damage = 10;
    private void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("zombie_bauch"))
            {
                //z_zombie_leben = GameObject.FindObjectOfType(typeof(Zombie_Leben)) as Zombie_Leben;
                //z_zombie_leben.addDamage(damage_zombie_bauch);
                hitInfo.collider.GetComponentInParent<Zombie_Leben>().addDamage(damage);
            }
            DestroyProjectile();
        }
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("zombie_hand"))
            {
                //z_zombie_leben = GameObject.FindObjectOfType(typeof(Zombie_Leben)) as Zombie_Leben;
                //z_zombie_leben.addDamage(damage_hand);
                hitInfo.collider.GetComponentInParent<Zombie_Leben>().addDamage(damage);
            }
            DestroyProjectile();
        }
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("zombie_kopf"))
            {
                //z_zombie_leben = GameObject.FindObjectOfType(typeof(Zombie_Leben)) as Zombie_Leben;
                //z_zombie_leben.addDamage(damage_zombie_kopf);
                hitInfo.collider.GetComponentInParent<Zombie_Leben>().addDamage(damage);
            }
            DestroyProjectile();
        }
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("zombie_boss_kopf"))
            {
                z_zombie_boss_leben = GameObject.FindObjectOfType(typeof(Zombie_Boss_Leben)) as Zombie_Boss_Leben;
                z_zombie_boss_leben.addDamage(damage_zombie_kopf);
                //hitInfo.collider.GetComponent<Zombie_Leben>().addDamage(damage);
            }
            DestroyProjectile();
        }
        // transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void DestroyProjectile()
    {
       // Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
