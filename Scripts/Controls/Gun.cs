using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Gun : MonoBehaviour, IShoot
{
    public float speed = 1;
    public GameObject bulletPrefab; 
    private Timer _timer;

    public bool TimerIsRunning()
    {
        return _timer.isRunning;
    }
    
    public void Shoot()
    {
        Vector3 gunPos = gameObject.transform.position;
        GameObject bullet = GameObject.Instantiate(bulletPrefab);
        bullet.transform.position = gunPos;
        var bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.AddForce(transform.up * speed, ForceMode2D.Impulse);
    }

    public void Reload()
    {
        _timer.ResetTimer();
    }

    void Start()
    {
        _timer = gameObject.GetComponent<Timer>();
    }
}
