using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI point_blue;
    public int counter= GameManager.Instance.Blue;
 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Basket")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            counter= GameManager.Instance.Blue+=10;
            point_blue.text = "Mavi Takým: " + counter.ToString();

        }
    }
}