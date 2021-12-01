using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected  GameObject goal;
    [SerializeField] private float speedBullet;

    public virtual void Start()
    {
        goal = GameObject.Find("GoalPlayer");
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 direction = (goal.transform.position - transform.position).normalized;
        transform.position += speedBullet * direction * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
