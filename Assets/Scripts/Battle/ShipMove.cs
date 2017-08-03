using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipMove : MonoBehaviour {
    public GameObject panel;
    Vector3 TargetLocation;
    public float speed = 3;
    private void Start()
    {
        TargetLocation = new Vector3(0,0,0);
    }
    private void FixedUpdate()
    {
        TargetLocation = transform.position;
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),0 );
        float Targetx = transform.position.x + speed*moveDirection.x;
        float Targety = transform.position.y + speed*moveDirection.y;
        RectTransform bounds = GetComponent<RectTransform>();
        
        if (Targetx>104 && Targetx <588)
        {
            TargetLocation.x = Targetx;
        }
        if (Targety > 180 && Targety < 600)
        {
            TargetLocation.y = Targety;
        }
        transform.position = TargetLocation;
    }
    private void shoot()
    {

    }
}
