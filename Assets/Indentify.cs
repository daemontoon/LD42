using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indentify : MonoBehaviour
{
    public int ID;
    GameObject test;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        test = collision.gameObject;
        if (test.GetComponent<BoxControll>().thrown == true && test.GetComponent<BoxControll>().moving == false && test.GetComponent<BoxControll>().color == ID)
        {

            test.GetComponent<BoxControll>().good = true;
            test.layer = 10;
            test.GetComponent<SpriteRenderer>().sortingOrder = -5;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        test = collision.gameObject;
        if (test.layer == 10 && test.GetComponent<BoxControll>().color == ID)
        {

            test.GetComponent<BoxControll>().good = false;

            test.layer = 9;
            test.GetComponent<SpriteRenderer>().sortingOrder = 0;
        }
    }

}
