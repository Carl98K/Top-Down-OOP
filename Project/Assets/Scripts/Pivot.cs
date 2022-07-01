using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour
{
    [SerializeField] private GameObject myPlayer;

    private Vector3 difference;
    private bool isFacingRight = true;

    private void Update() {
        //Debug.Log(difference);

        if(difference.x < 0.0f && isFacingRight == true)
        {
            isFacingRight = false;
            myPlayer.transform.Rotate(0, -180, 0);
        }
        else if(difference.x > 0.0f && isFacingRight == false)
        {
            isFacingRight = true;
            myPlayer.transform.Rotate(0, 180, 0); 
        }
            
    }

    private void FixedUpdate()
    {
        difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;    
        difference.Normalize();

        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotationZ);

        if(rotationZ < -90 || rotationZ > 90)
        {
            if(myPlayer.transform.eulerAngles.y == 0)
            {
                transform.localRotation = Quaternion.Euler(180, 0, -rotationZ);
            }
            else if(myPlayer.transform.eulerAngles.y == 180)
            {
                transform.localRotation = Quaternion.Euler(180, 180, -rotationZ);
            }
        }
    }
}
