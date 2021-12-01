using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{

    private Animator anim;
    private float moveVertical, rotation = 70f;
    private bool isDeath = false;

    [SerializeField] int lifePlayer;
    [SerializeField] float speedPlayer;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform position;

    public static event Action<int> onLivesChange;
    public static event Action onDeath;

    void Start()
    {
        anim = GetComponent<Animator>();
        onLivesChange?.Invoke(lifePlayer);
    }

    void Update()
    {
        if(isDeath == false)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                anim.SetTrigger("isShoot");
                Instantiate(bullet, position);
            }
        }
    }

    void FixedUpdate()
    {
       if(isDeath == false)
       {
            Move();
            Rotation();
       }
    }

    private void Move()
    {
        moveVertical = Input.GetAxis("Vertical");
        transform.Translate(0, 0, moveVertical * Time.deltaTime * speedPlayer);
        anim.SetFloat("SpeedY", moveVertical);
    }

    private void Rotation()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0.0f, Time.deltaTime * -(rotation), 0.0f);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0.0f, Time.deltaTime * rotation, 0.0f);
        }
    }

    public void ChangePositionY()
    {
        transform.position = new Vector3 (transform.position.x,transform.position.y+0.27f,transform.position.z);
    }

    public void ResetChangePositionY()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y -0.27f, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            lifePlayer--;
            onLivesChange?.Invoke(lifePlayer);

            if (lifePlayer >= 1)
            {
                anim.SetTrigger("isHurt");
            }

            if (lifePlayer == 0)
            {
                anim.SetTrigger("isDeath");
                isDeath = true;
                onDeath?.Invoke();
            }
        }

        if (other.CompareTag("Life"))
        {
            lifePlayer ++;
            onLivesChange?.Invoke(lifePlayer);
            Destroy(other.gameObject);
        }
    }
}
