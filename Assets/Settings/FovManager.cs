using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FovManager : MonoBehaviour
{
    public Transform[] target;
    public float viewAngle;
    public AudioSource sound;
    public Transform myCamera; 

    void Update()
    {
      CanSeeTarget(target, viewAngle);
    }


    void CanSeeTarget(Transform[] target, float viewAngle) {
        foreach(Transform obj in target)
        {
          float distance = Vector3.Distance(myCamera.position, obj.position);
          Vector3 toTarget = obj.position - myCamera.position;
          //checks if the angle btw the object and the target is within the given FOVAngle
           

          if (Vector3.Angle(myCamera.forward, toTarget) <= viewAngle)
          {
            Debug.DrawRay(myCamera.position, toTarget, Color.green);
            obj.GetComponent<Outline>().enabled = true;

            RaycastHit hit;
            if ((Physics.Raycast(myCamera.position, toTarget, out hit)))
              {
              Debug.DrawRay(myCamera.position, toTarget, Color.green);
              }
            //calculate angle
            float xyAngle = Vector3.SignedAngle(toTarget, myCamera.forward , Vector3.up);            
            // Debug.Log(obj.name + " at " + xyAngle + "deg");
            
            if ((-15 < xyAngle) && (xyAngle < 15) && distance < 40)
            {
              //Debug.Log("The " + obj.name + " detected at " + distance + " units from you!" + " viewAngle:" + viewAngle);
              Debug.Log("The " + obj.name + " in front of you!" + " @" + distance);
            }
            else if((15 < xyAngle) && (xyAngle < 90) )
            {
              Debug.Log("The " + obj.name + " to your left!");
            }
            else if((-15 > xyAngle) && (xyAngle > -90))
            {
              Debug.Log("The " + obj.name + " to your right!");
            }
          }else{
              obj.GetComponent<Outline>().enabled = false;
          }
        }
       } 
    }
