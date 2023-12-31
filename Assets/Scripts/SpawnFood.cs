using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnFood : MonoBehaviour
{
    public GameObject foodPrefab;
    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;

    void Start()
    {
        InvokeRepeating("Spawn", 2, 2);
    }
    void Spawn()
    {
        int x = (int)Random.Range(borderLeft.position.x, borderRight.position.x);
        int y =(int)Random.Range(borderBottom.position.y, borderTop.position.y);
        Instantiate(foodPrefab, new Vector2(x, y), Quaternion.identity);
    }


}
