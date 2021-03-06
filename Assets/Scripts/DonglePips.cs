﻿using UnityEngine;
using System.Collections;

public class DonglePips : MonoBehaviour {
    public Transform[] chillen;


    Vector3 center;
    public float ModifyRadius;
    public Vector3 min;
    public Vector3 max;
    public float scaleSpeed;

    bool maxtarget;

    public float deadzone;
    public float rotatespeed;

    Vector3 target;
    void Update()
    {
        transform.Rotate(Vector3.up, rotatespeed * Time.deltaTime);

  

    }



   public void DoIt(float rad)
    {
        int i = 0;
        foreach (Transform k in chillen)
        {
            ModifyRadius = rad;
            Vector3 pos = RandomCircle(Vector3.zero, rad, i *(360 / chillen.Length));
            Ray m = new Ray(new Vector3(k.position.x, k.position.y + 40, k.position.z), Vector3.down);
            RaycastHit hit;
            float y = 0;
            if (Physics.Raycast(m,  out hit, Mathf.Infinity, transform.parent.GetComponent<PlayerDongle>().maskingjunk))
            {
                y = hit.point.y + transform.parent.GetComponent<PlayerDongle>().localhover;
            }

            k.localPosition = pos;
            i++;
            Vector3 glob = k.position;
            glob.y = y;
            k.position = glob;
        }
    }

    Vector3 RandomCircle(Vector3 center, float radius, float ang)
    {
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y;
        pos.z = center.z + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        return pos;
    }

}
