using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Door.instance != null)
        {
            Door.instance.collectablesCount++;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);

            if (Door.instance != null)
            {
                Door.instance.DecrementCollectables();
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
