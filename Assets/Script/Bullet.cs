using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    bool isShooting = false;
    Vector3 destPosition;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isShooting)
        {
            transform.position = Vector3.MoveTowards(transform.position, destPosition, 0.3f);
            if (transform.position == destPosition)
            {
                isShooting = false;
                GameManager.Instance.LoadAnimal();
            }
        }
    }

    public void Shoot(Vector3 destPos)
    {
        destPosition = destPos;
        isShooting = true;
    }
}
