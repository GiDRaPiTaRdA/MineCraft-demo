using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OcclusionObject : MonoBehaviour
{
    private Renderer rend;
    public float displayTime;

	// Use this for initialization
	void Start () {
		
	}


    private void OnEnable()
    {
        rend = this.gameObject.GetComponent<Renderer>();
        this.displayTime = -1;
    }

	// Update is called once per frame
	void Update () {
	    if (this.displayTime > 0)
	    {
	        this.displayTime -= Time.deltaTime;
	        this.rend.enabled = true;
	    }
	    else
	    {
	        this.rend.enabled = false;
	    }
	}

    public void HitOcclude(float time)
    {
        this.displayTime = time;
        this.rend.enabled = true;
    }
}
