using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRunAway : MonoBehaviour
{
    public float speed;
    public Transform target;
    public float minimumDistance;
    public GameObject projectile;
    public float timeBetweenShots;
    public float nextShotTime;

    private void Update()
    {
        if(Time.time > nextShotTime)
        {
            GetComponent<Animator>().SetTrigger("InRange");
            Instantiate(projectile, transform.position, Quaternion.identity);
            nextShotTime = Time.time + timeBetweenShots;
        }
        if (Vector2.Distance(transform.position, target.position) < minimumDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
        }
    }
}
