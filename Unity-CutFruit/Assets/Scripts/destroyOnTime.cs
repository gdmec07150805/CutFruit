using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 根据时间销毁分瓣水果
/// </summary>
public class destroyOnTime : MonoBehaviour {
    public float desTime = 2;
	// Use this for initialization
	void Start () {
        Invoke("Dead",desTime);
	}

	void Dead () {
        Destroy(gameObject);
	}
}
