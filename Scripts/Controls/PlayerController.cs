using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Gun _gun;
    public float speed = 1;
    private Collider2D _leftBoundaryCollider;
    private Collider2D _rightBoundaryCollider;
    private bool _alive;
    private Rigidbody2D _rigidbody2D;

    public bool IsAlive()
    {
        return _alive;
    }

    public void Kill()
    {
        _alive = false;
        GameObject.Find("UIManager").GetComponent<UIManager>().SetAlive(false);
    }
    
    private void Awake()
    {
        _alive = true;
        _rigidbody2D = gameObject.transform.GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Camera myCam = Camera.main;
        _gun = gameObject.transform.GetChild(0).GetComponent<Gun>();
    }
    
    void Update()
    {
        Vector3 movement = new Vector3();
        if (Input.GetKey(KeyCode.A))
        {
            movement += -gameObject.transform.right;
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            movement += gameObject.transform.right;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!_gun.TimerIsRunning())
            {
                _gun.Shoot();
            }
            _gun.Reload();
        }
        
        _rigidbody2D.velocity = movement * speed;
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        //GameOver.ShowGameOver();
    }
}
