using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDragon : MonoBehaviour
{
    public GameObject dragonEggPrefab;
    public float speed = 1;
    public float timeBetweenEggDrops = 3f;
    public float leftRightDistance = 10f;
    public float chanceDirections = 0.1f;

    void Start()
    {
        Invoke("DropEgg", 2f);

    }

    void DropEgg()
    {
        Vector3 myVector = new Vector3(0.0f, 5.0f, 0.0f);
        GameObject egg = Instantiate<GameObject>(dragonEggPrefab);
        egg.transform.position = myVector + transform.position;
        Invoke("DropEgg", timeBetweenEggDrops);

    }

    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftRightDistance)
            speed = Mathf.Abs(speed);
        else if (pos.x > leftRightDistance)
            speed = -Mathf.Abs(speed);

    }

    private void FixedUpdate()
    {
        if (Random.value < chanceDirections)
            speed *= -1;
    }
}
