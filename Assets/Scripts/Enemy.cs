using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int maxHealth = 100;

    public int damage = 1;

    public int Damage
    {
        get { return damage; }
        /*set { damage = value; }*/
    }

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
            Die();
    }

    private void Die()
    {
        Score.enemiesKilled += 1;
        Score.coins += 1;
        // disable the script and the collider
        GetComponent<CapsuleCollider2D>().enabled = false;
        Destroy(gameObject);
        this.enabled = false;
    }
}
