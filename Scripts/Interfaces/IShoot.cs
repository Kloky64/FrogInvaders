using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IShoot
{
    public static float Speed;
    private static Timer _timer;
    public void Shoot();
    public void Reload();
}
