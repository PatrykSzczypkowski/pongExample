using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class Ball : MonoBehaviour
{
    public float speed = 30;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "RacketLeft")
        {
            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);

            Vector2 dir = new Vector2(1, y).normalized;

            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        if (col.gameObject.name == "RacketRight")
        {
            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);

            Vector2 dir = new Vector2(-1, y).normalized;

            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        if (col.gameObject.name == "GoalLeft")
        {
            GameObject.Find("ScoreRight").GetComponent<Score>().addScoreRight(); 
            transform.position = new Vector2(0, 0);
            GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
        }

        if (col.gameObject.name == "GoalRight")
        {
            GameObject.Find("ScoreLeft").GetComponent<Score>().addScoreLeft(); 
            transform.position = new Vector2(0, 0);
            GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
        }
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight)
    {
        return (ballPos.y - racketPos.y) / racketHeight;
    }
}
