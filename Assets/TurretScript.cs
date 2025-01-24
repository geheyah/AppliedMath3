using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class TurretScript : MonoBehaviour
{
    public Transform player;
    public Transform turret;
    public GameObject bullet;

    public bool canShoot = true;

    private IEnumerator Shoot()
    {
        GameObject bulletObject = Instantiate(bullet,turret.position, turret.rotation);
        Bullet bulletScript = bulletObject.GetComponent<Bullet>();
        bulletScript.target = player.gameObject;
        canShoot = false;
        yield return new WaitForSeconds(1f);
        canShoot = true;
    }
    void Update()
    {
        var distance = (turret.position - player.position).magnitude;

        if (distance <= 10f)
        {
            Look(turret.transform);

            if (canShoot)
            {
                StartCoroutine(Shoot());
            }
        }
    }
    
    float Dot(Vector3 start, Vector3 end)
    {
        return start.x * end.x + start.y * end.y + start.z * end.z;
    }

    Vector3 Dot2(Vector3 start, Vector3 end)
    {
        return new Vector3(start.x * end.x, start.y * end.y, start.z * end.z);
    }

    void Look(Transform objectToRotate)
    {
        var dotproduct = Dot2(objectToRotate.position, player.position);
        var angle = Mathf.Atan2(dotproduct.y, dotproduct.x) * Mathf.Rad2Deg;
        
        objectToRotate.rotation = Quaternion.Lerp(objectToRotate.rotation, Quaternion.Euler(0, 0, angle), Time.deltaTime * 5f);
    }
}
