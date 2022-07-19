using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FovManager : MonoBehaviour
{
    // public GameObject[] objects;
    public Transform[] target;

    public float viewAngle;
    public float viewRange;

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
          }else{
              obj.GetComponent<Outline>().enabled = false;
          }
        }
       }


}
