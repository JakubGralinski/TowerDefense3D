using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    [SerializeField] Transform partToRotate;
    [SerializeField] Transform firePoint;

    public GameObject BulletPf;
    public string EnemyTag = "Enemy";

    [Header("Features")]
    public float FireRate = 1f;
    public float Range = 15f;
    [SerializeField] float turnSpeed = 10f;
    private float fireCountdown = 0f;

    private Transform target;
    private Enemy enemyTarget;

    [Header("Use Laser")]
    public int DmgOverTime = 30;
    public float SlowFactor = .5f; // if a slow factor == 0 theres no movement, if it == 1 theres no slow

    public bool UseLaser = false;
    public LineRenderer LineRenderer;
    public ParticleSystem ImpactEffect;
    public Light ImpactLight;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, .5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            if (UseLaser)
            {
                if (LineRenderer.enabled)
                {
                    LineRenderer.enabled = false;
                    ImpactEffect.Stop();
                    ImpactLight.enabled = false;
                }
            }
            return;
        }

        //looking at target
        LockOnTheTarget();

        if (UseLaser)
        {
            Laser();
        }
        else
        {
            if (fireCountdown <= 0)
            {
                Shoot();
                fireCountdown = 1f / FireRate;
            }
        }

        fireCountdown -= Time.deltaTime;
    }

    void Laser()
    {
        enemyTarget.TakeDamage(DmgOverTime * Time.deltaTime);
        enemyTarget.Slow(SlowFactor);

        if (!LineRenderer.enabled)
        {
            LineRenderer.enabled = true;
            ImpactEffect.Play();
            ImpactLight.enabled = true;
        }

        LineRenderer.SetPosition(0, firePoint.position);
        LineRenderer.SetPosition(1, target.position);

        Vector3 dir = firePoint.position - target.position;

        ImpactEffect.transform.position = target.position + dir.normalized;

        ImpactEffect.transform.rotation = Quaternion.LookRotation(dir);
    }

    void LockOnTheTarget()
    {
        Vector3 dir = (target.position - transform.position).normalized;
        Quaternion lookRot = Quaternion.LookRotation(dir);

        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRot, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    private void Shoot()
    {
        GameObject bulletGo = (GameObject)Instantiate(BulletPf, firePoint.position, firePoint.rotation);
        BulletScript bullet = bulletGo.GetComponent<BulletScript>();

        if (bullet != null)
        {
            bullet.SeekTheEnemy(target);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(EnemyTag);
        float shortestDist = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (var enemy in enemies)
        {
            float distToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distToEnemy <= shortestDist)
            {
                shortestDist = distToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDist <= Range)
        {
            target = nearestEnemy.transform;
            enemyTarget = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }
    }
}
