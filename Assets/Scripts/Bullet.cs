using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int demageAmount = 40;
    public float bulletSpeed = 5f;

    private Transform target;

    public Transform Target
    {
        set
        {
            target = value;
            /*if (target != null)
            {
                transform.LookAt(target);
            }*/
        }
    }

    // Update is called once per frame
    void Update()
    { 
        transform.position = Vector2.MoveTowards(transform.position, target.position, bulletSpeed * Time.deltaTime);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            /*other.gameObject.GetComponent<Enemy>().TakeDamage(demageAmount);*/
            Destroy(gameObject);
        }
    }
}
