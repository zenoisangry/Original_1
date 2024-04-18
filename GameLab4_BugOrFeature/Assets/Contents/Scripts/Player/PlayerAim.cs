using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    private Transform aim;

    private void Awake()
    {
        aim = transform.Find("Aim"); 
    }
    //public static Vector3 GetMouseWorldPosition()
   // {
        //Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
       // vec.z = 0f;
    //}

    private void Update()
    {
        //Vector3 mousePosition; 
    }
}
