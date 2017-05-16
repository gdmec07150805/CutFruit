using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cutController : MonoBehaviour {
    public GameObject halfFruit1;
    public GameObject halfFruit2;
    private bool dead=false;
    public AudioClip ac;

    public void OnCut()
    {
        if (dead)
        {
            return;
        }
        //Contains名字包含（"boom"）的都算
        if (gameObject.name.Contains("boom"))
        {
            UIscore._instance.LessScore();
        }
        else
        {
            UIscore._instance.AddScore();
            GameObject go1 = Instantiate<GameObject>(halfFruit1, transform.position, Quaternion.identity);
            GameObject go2 = Instantiate<GameObject>(halfFruit2, transform.position, Quaternion.identity);
            //为分瓣的水果添加单元内乘5倍的力，ForceMode.Impulse为冲力
            go1.GetComponent<Rigidbody>().AddForce(Random.insideUnitSphere * 10f, ForceMode.Impulse);
            go2.GetComponent<Rigidbody>().AddForce(Random.insideUnitSphere * 10f, ForceMode.Impulse);
            AudioSource.PlayClipAtPoint(ac, transform.position);
        }
            Destroy(gameObject);
            dead = true;
    }
}
