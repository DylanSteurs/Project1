using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{
    Vector2 dir = Vector2.right;

    void Start()
    {
        InvokeRepeating("Move", 0.045f, 0.045f);   
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            dir = Vector2.right;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            dir = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            dir = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            dir = Vector2.down;
        }
    }
    List<Transform> tail = new List<Transform>();   
    void Move()
    {
        Vector2 v = transform.position;
        transform.Translate(dir);
        if (ate)
        {
            GameObject g =(GameObject)Instantiate(tailPrefab, v, Quaternion.identity);

            tail.Insert(0, g.transform);
            ate = false;    
        }

        if (tail.Count > 0)
        {
            tail.Last().position = v;
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count-1);
        }
    }
    bool ate = false;
    public GameObject tailPrefab;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.name.StartsWith("FoodPrefab"))
        {
            ate = true;
            Destroy(coll.gameObject);
        }
        else if(coll.name.StartsWith("Border"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}
