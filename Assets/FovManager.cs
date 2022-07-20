using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FovManager : MonoBehaviour
{
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
          Vector3 toTarget = obj.position - transform.position;
          //checks if the angle btw the object and the target is within the given FOVAngle
          if (Vector3.Angle(transform.forward, toTarget) <= viewAngle)
          {
            //Debug.DrawRay(transform.position, toTarget, Color.green);
            //Debug.Log(obj.name);
            obj.GetComponent<Outline>().enabled = true;
            // float angle = Vector3.Angle(toTarget, transform.forward);
            // if (angle<5.0f){
            //     print("There's an obstacle in front");
            //     //Debug.Log(obj.name);
            // }
            // else if(angle>5.0f)
            // {
            //   print("here");
            //   Debug.Log(obj.name);
            // }
            // else if(angle>-5.0f){
            //   print("angle????");
            //   Debug.Log(obj.name);
            // }
            // else if(angle<-5.0f)
            // {
            //   print("hello!!!");
            //   Debug.Log(obj.name);
            // }

            //Cast a ray against collider
            RaycastHit hit;
            if (Physics.Raycast(transform.position, toTarget, out hit))
              {
              Debug.DrawRay(transform.position, toTarget, Color.green);
              sound.Play();
              Debug.Log("Did Hit");
              }

            //project angle of target to XY plane
            Vector3 projectedVector = Vector3.ProjectOnPlane(toTarget, transform.forward);
            //calculate angle
            float xyAngle = Vector3.SignedAngle(projectedVector, transform.up, transform.forward);
            Debug.Log(obj.name);
            print(xyAngle);

            if (xyAngle == 90)
            {
              Debug.Log(obj.name);
              print("There's an object in front of you!");
            }
            else if(xyAngle == 0 )
            {
              Debug.Log(obj.name);
              print("There's an object to your right!");
            }
            else if(xyAngle == 180)
            {
              Debug.Log(obj.name);
              print("There's an object to your left!");
            }
          }else{
              obj.GetComponent<Outline>().enabled = false;
          }
        }
       }


}
