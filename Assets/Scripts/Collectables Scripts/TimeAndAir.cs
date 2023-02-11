using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAndAir : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (gameObject.name == "Air")
            {
                GameObject.Find("GamePlayController").GetComponent<AirTimer>().air += 15f;
            } else
            {
                GameObject.Find("GamePlayController").GetComponent<LevelTimer>().timer += 15f;
            }
            Destroy(gameObject);
        }
    }
}
