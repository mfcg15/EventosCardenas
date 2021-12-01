using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    protected Animator anim;
    private GameObject player;
    private float rotation = 70f, temporary, finalTime, shootTime = 2.2f, distanceShoot, timeDestroy = 3f, maxLifeEnemy;
    private bool isAttack = false, seeThePlayer, flag = true, isDeath = false;
    [SerializeField] private float lifeEnemy = 5f;
    [SerializeField] private GameObject shootPoint, bullet;
    [SerializeField] private float rangoOfView;
    [SerializeField] private Transform position;
    [SerializeField] Image lifeBarEnemy;
    [SerializeField] GameObject panelEnemy;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player");
        distanceShoot = rangoOfView - 1f;
        maxLifeEnemy = lifeEnemy;
    }

    void Update()
    {
      
        if (isDeath)
        {
            timeDestroy -= Time.deltaTime;

            if (timeDestroy <= 0)
            {
                panelEnemy.SetActive(false);
                Destroy(gameObject);
            }
        }
        else
        {
            FindPlayer();
        }
    }

    private void FindPlayer()
    {
      
        if ((Vector3.Distance(player.transform.position, transform.position) < rangoOfView))
        {
            seeThePlayer = true;
            RaycastHitAttack(shootPoint.transform);
        }
        else
        {
            seeThePlayer = false;
            isAttack = false;
        }

        LookAtPlayer();
    }

    private void LookAtPlayer()
    {
        Vector3 direction = player.transform.position - transform.position;
        Quaternion newRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, rotation * Time.deltaTime);
    }

    private void RaycastHitAttack(Transform point)
     {
         RaycastHit hit;
         if (Physics.Raycast(point.position, point.TransformDirection(Vector3.forward), out hit, distanceShoot))
         {
             if (hit.transform.CompareTag("Player"))
             {
                isAttack = true;
                Attack();
             }
         }
     }

    private void Attack()
    {
        
        if (flag)
        {
            temporary = shootTime;
            flag = false;
            finalTime = temporary;
            anim.SetTrigger("isShoot");
            Instantiate(bullet, position);
        }

        shootTime -= Time.deltaTime;

        if (shootTime <= 0)
        {
            flag = true;
            shootTime = finalTime;
        }
    }
     private void DrawRay(Transform point)
     {
         Gizmos.color = Color.blue;
         Vector3 direction = point.TransformDirection(Vector3.forward) * distanceShoot;
         Gizmos.DrawRay(point.position, direction);
     }

     private void DrawRaycast()
     {
         DrawRay(shootPoint.transform);
     }

    private void OnDrawGizmos()
    {

        if (seeThePlayer)
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.green;
        }

        Gizmos.DrawWireSphere(transform.position, rangoOfView);

        if (isAttack)
        {
            DrawRaycast();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BulletPlayer"))
        {
            lifeEnemy--;
            lifeBarEnemy.fillAmount = lifeEnemy / maxLifeEnemy;

            if (lifeEnemy >= 1)
            {
                anim.SetTrigger("isHurt");
            }

            if (lifeEnemy==0)
            {
                anim.SetTrigger("isDeath");
                isDeath = true;
            }
        }
    }
}

