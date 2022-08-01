using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI point_blue;
    public int frPoint;
    public int counter;
    
 
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
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Basket")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            counter= counter+frPoint;
            point_blue.text = counter.ToString();

        }
    }
}