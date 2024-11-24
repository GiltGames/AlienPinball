using System;
using Unity.Mathematics;
using UnityEngine;

public class Move : MonoBehaviour
{

    public float alienSp = 2;
    public float alienUL = 10;
    public float alienLL = -10;
    public Score Scr;
    Vector3 strtPosA;
    public AudioSource Exp;
    public AudioClip ExpSound;
    public OutofBound OOB;


    Rigidbody2D shot;
    public GameObject targetObjectShot;
    public Vector3 shotStart;
    public GameObject targetExp;
    public Vector3 expStart;
    public int addScore=0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        strtPosA = transform.position;
        Debug.Log("Start: " + strtPosA);

        // shot location 

        shot = targetObjectShot.GetComponent<Rigidbody2D>();
        shotStart = shot.position;

        //explosion location - not a rigid body 
        expStart = targetExp.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        // ship moves right

        transform.Translate(alienSp * Time.deltaTime, 0, 0);

        if (transform.position.x > alienUL)
        {
            transform.position = new Vector3(alienLL, strtPosA.y, 0);

        }
        Debug.Log("Ongoing: " + strtPosA);
    }

    // Detect if shot hits the ship 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioSource.PlayClipAtPoint(ExpSound, transform.position);
        // moves explosion in to replace ship

        targetExp.transform.position = transform.position;
        addScore = Mathf.RoundToInt( transform.position.x) + 10;

        // reset fired flag

        OOB.fired = false;

        transform.position = new Vector3(alienLL, strtPosA.y, 0);
        //update score

        Scr.gameScore += addScore;
        //reset shot position

        shot.position = shotStart;
        shot.linearVelocity.Set(0,0);



        //  Debug.Log("Change: " + strtPosA);
    }
}
