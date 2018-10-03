using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAction : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetMouseButtonDown(0))
	    {
	        RaycastHit hit;
	        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

	        if (Physics.Raycast(ray, out hit, 1000.0f))
	        {
	            Vector3 blockPos = hit.point - hit.normal/2;

	            blockPos.x = (float) Math.Round(blockPos.x, MidpointRounding.AwayFromZero);
	            blockPos.y = (float) Math.Round(blockPos.y, MidpointRounding.AwayFromZero);
	            blockPos.z = (float) Math.Round(blockPos.z, MidpointRounding.AwayFromZero);

	            GameManager.DestroyBlockObject(blockPos);
	        }
	    }
	}

    void OnMouseDown()
    {

        //GameManager.DestroyBlockObject(this.gameObject);
    }
}
