using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Reticle : MonoBehaviour
{
    [SerializeField] private LineRenderer playerLR; 

    public void RenderLine(Vector3 startPoint, Vector3 endPoint){
        playerLR.enabled = true;

        Vector3[] points = new Vector3[2]; 
        points[0] = startPoint;
        points[1] = endPoint;

        playerLR.SetPositions(points);
    }

    public void EndLine(){
        playerLR.enabled = false;
    }
}
