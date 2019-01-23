using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaRayCast : MonoBehaviour {

    public LayerMask layermask;

    RaycastHit hit;
	void Update () {
		if(Physics.Raycast(Vector3.zero,Vector3.up, 3f))
        {
            Debug.Log("ENTRO");
        }
        Debug.DrawRay(Vector3.zero, Vector3.up * 3f, Color.green);
	}
}
