﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start_Rotate : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0,0,10) * Time.deltaTime);
    }
}
