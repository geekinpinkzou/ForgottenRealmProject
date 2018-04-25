using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundTransform : MonoBehaviour {

    public float moveSpeed = 5f;
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(Vector3.left*moveSpeed*Time.deltaTime);
        Vector3 pos = this.transform.position;
        if (pos.x <= -20.24f)
        {
            this.transform.position = new Vector3(pos.x + 20.24f * 2, pos.y, pos.z);
        }

    }
}
