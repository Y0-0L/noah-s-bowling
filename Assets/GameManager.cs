using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject basePref;
    public GameObject bulletPref;
    public Transform baseSpwanPos;
    public Transform bulletSpawnPos;

    bool ReadyToShoot = false;
    private GameObject loadedBullet;

    public float moveSpeed;
    private bool isMove;
    private Vector3 destination;

    // Start is called before the first frame update
    void Start()
    {
        GameStart();
    }

    // Update is called once per frame
    void Update()
    {
        if (ReadyToShoot && Input.GetMouseButtonDown(0))
        {
            ReadyToShoot = false;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            {
                Debug.Log($"충돌된 물체 이름 : {hit.transform.name}, Position : {hit.point}");
                destination = hit.point;
                loadedBullet.GetComponent<Bullet>().Shoot(destination);
            }
        }
    }

    void GameStart()
    {
        SpawnBase();
        LoadAnimal();
    }

    void SpawnBase()
    {
        Instantiate(basePref,baseSpwanPos.position, Quaternion.identity);
    }

    void LoadAnimal()
    {
        loadedBullet = Instantiate(bulletPref, bulletSpawnPos.position, Quaternion.identity);
        ReadyToShoot = true;
    }
}
