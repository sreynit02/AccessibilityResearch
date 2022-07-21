using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FovManager : MonoBehaviour
{
    // Vector3 projectedVector;
    // Vector3 tempAngle;
    // public GameObject[] objects;
    public Transform[] target;
    public float viewAngle;
    public AudioSource sound;
    void Update()
    {
      CanSeeTarget(target, viewAngle);
    }


    void CanSeeTarget(Transform[] target, float viewAngle) {
        foreach(Transform obj in target)
        {
          float distance = Vector3.Distance(transform.position, obj.position);
          Vector3 toTarget = obj.position - transform.position;
          //checks if the angle btw the object and the target is within the given FOVAngle
           

          if (Vector3.Angle(transform.forward, toTarget) <= viewAngle)
          {
            Debug.DrawRay(transform.position, toTarget, Color.green);
            //Debug.Log(obj.name);

            obj.GetComponent<Outline>().enabled = true;

            RaycastHit hit;
            if ((Physics.Raycast(transform.position, toTarget, out hit)))
              {
              Debug.DrawRay(transform.position, toTarget, Color.green);
              }
            //calculate angle
            float xyAngle = Vector3.SignedAngle(toTarget, transform.forward , Vector3.up);            
            // Debug.Log(obj.name + " at " + xyAngle + "deg");
            
            if ((-15 < xyAngle) && (xyAngle < 15))
            {
              //Debug.Log(obj.name);
              //Debug.Log("The " + obj.name + " detected at " + distance + " units from you!" + " viewAngle:" + viewAngle);
              Debug.Log("The " + obj.name + " in front of you!");
            }
            else if((15 < xyAngle) && (xyAngle < 90) )
            {
              //Debug.Log(obj.name);
              Debug.Log("The " + obj.name + " to your left!");
            }
            else if((-15 > xyAngle) && (xyAngle > -90))
            {
              //Debug.Log(obj.name);
              Debug.Log("The " + obj.name + " to your right!");
            }
          }else{
              obj.GetComponent<Outline>().enabled = false;
          }
        }
       } 
    }
