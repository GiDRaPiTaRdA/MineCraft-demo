using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Occlusion : MonoBehaviour
{

    public int rayAmmount = 1500;
    public int rayDistance = 300;
    public float stayTime = 2;

    public Camera cam;

    public Vector2[] rPoints;

	// Use this for initialization
	void Start ()
	{
	    this.cam = gameObject.GetComponent<Camera>();
        this.rPoints =  new Vector2[this.rayAmmount];

        this.GetPoints();
	}
	
	// Update is called once per frame
	void Update () {
		this.CastRays();
	}

    void GetPoints()
    {
        float x = 0;
        float y = 0;

        for (int i = 0; i < this.rayAmmount; i++)
        {
            if (x > 1)
            {
                x = 0;
                y += 1 / Mathf.Sqrt(this.rayAmmount);
            }

            this.rPoints[i] =  new Vector2(x,y);
            x += 1 / Mathf.Sqrt(this.rayAmmount);
        }
    }

    void CastRays()
    {
        for (int i = 0; i < this.rayAmmount; i++)
        {
            Ray ray;
            RaycastHit hit;
            OcclusionObject ocl;

            ray = this.cam.ViewportPointToRay(new Vector3(this.rPoints[i].x, this.rPoints[i].y, 0));
            if (Physics.Raycast(ray, out hit, this.rayDistance))
            {
                if (ocl = hit.transform.GetComponent<OcclusionObject>())
                {
                    ocl.HitOcclude(this.stayTime);
                }
            }
        }
    }
}
