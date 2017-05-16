using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start_cutController : MonoBehaviour
{
    public GameObject halfFruit1;
    public GameObject halfFruit2;
    private bool dead = false;
    public AudioClip ac;
    public start_gameContol gameController;
    private start_gameContol gameControl;
    private void Start()
    {
        gameControl = Instantiate(gameController) as start_gameContol;
    }
    public void start_OnCut()
    {

        //Contains名字包含（"boom"）的都算
        if (gameObject.name.Contains("boom"))
        {
            gameControl.loadLevel2();
        }
        else
        {

            GameObject go1 = Instantiate<GameObject>(halfFruit1, transform.position, Quaternion.identity);
            GameObject go2 = Instantiate<GameObject>(halfFruit2, transform.position, Quaternion.identity);
            //为分瓣的水果添加单元内乘5倍的力，ForceMode.Impulse为冲力
            go1.GetComponent<Rigidbody>().AddForce(Random.insideUnitSphere * 10f, ForceMode.Impulse);
            go2.GetComponent<Rigidbody>().AddForce(Random.insideUnitSphere * 10f, ForceMode.Impulse);
            AudioSource.PlayClipAtPoint(ac, transform.position);
            Destroy(gameObject);
            if (gameObject.name.Contains("sandia"))
            {
                gameControl.loadLevel();
            }
            else if (gameObject.name.Contains("peach"))
            {
                gameControl.loadLevel2();
            }
        }
    }
}
