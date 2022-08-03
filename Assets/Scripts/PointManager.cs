using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI point_blue;
    public int frPoint;
    static int counter;
     

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (gameObject.tag == "gr_orange")
        {
            frPoint = 20;
        }else if (gameObject.tag == "tr_orange")
        {
            frPoint = 30;
        }
        else if (gameObject.tag == "gr_banana")
        {
            frPoint = 30;
        }
        else if (gameObject.tag == "tr_banana")
        {
            frPoint = 50;
        }
        else if (gameObject.tag == "gr_coconut")
        {
            frPoint = 25;
        }
        else if (gameObject.tag == "tr_coconut")
        {
            frPoint = 55;
        }
        else if (gameObject.tag == "gr_apple")
        {
            frPoint = 15;
        }
        else if (gameObject.tag == "tr_apple")
        {
            frPoint = 25;
        }
        else if (gameObject.tag == "pump")
        {
            frPoint = 10;
        }
        else if (gameObject.tag == "gr_corn")
        {
            frPoint = 15;
        }
        else if (gameObject.tag == "tr_corn")
        {
            frPoint = 20;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Basket")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            
            counter= counter+frPoint;
            point_blue.text = counter.ToString();
           
            //check.Play(0);
        }

        if (collision.gameObject.layer == 9)
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
    }



}