using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class TongueShoot : MonoBehaviour, IShoot
{
    public float speed = 1;
    public GameObject bulletPrefab; 
    private Timer _timer;

    public void Shoot()
    {
        Vector3 tonguePos = gameObject.transform.position;
        GameObject bullet = GameObject.Instantiate(bulletPrefab);
        bullet.transform.position = tonguePos;
        var bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.AddForce(-transform.up * speed, ForceMode2D.Impulse);
        Physics2D.IgnoreCollision(bullet.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
    }

    public void Reload()
    {
        _timer.ResetTimer();
        /*if (_timer.isRunning == false)
        {
            _timer.remainingTime = _timer.settedTime;
            _timer.isRunning = true;
        }*/
    }
    
    void Start()
    {
        _timer = gameObject.GetComponent<Timer>();
    }
    
    void Update()
    {
        if (!_timer.isRunning)
        {
            Shoot();
        }
        Reload();
    }
}
