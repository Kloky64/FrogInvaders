using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GeneralCollisions : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyObject"))
        {
            GameObject.Find("Score").GetComponent<Score>().UpdateScore();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
