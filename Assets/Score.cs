using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Animations;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static int scoreLeft;
    public static int scoreRight;

    public void addScoreLeft()
    {
        scoreLeft += 1;
        transform.GetChild(scoreLeft - 1).GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
    }

    public void addScoreRight()
    {
        scoreRight += 1;
        transform.GetChild(scoreRight - 1).GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreLeft = 0;
        scoreRight = 0;
        foreach (Transform child in transform)
            child.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

}
