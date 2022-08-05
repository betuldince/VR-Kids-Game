using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class changeText : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI Point;
    private int frPoint;
   
    void Start()
    {
        if (gameObject.tag == "gr_orange")
        {
            frPoint = 20;
        }
        else if (gameObject.tag == "tr_orange")
        {
            frPoint = 30;
        }
        else if (gameObject.tag == "tr_orange_2")
        {
            frPoint = 50;
        }
        else if (gameObject.tag == "tr_orange_3")
        {
            frPoint = 80;
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
        else if (gameObject.tag == "cake")
        {
            frPoint = 100;
        }
        Point.text = frPoint.ToString();
 

    }

    // Update is called once per frame
    void Update()
    {


    }

}
