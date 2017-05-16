using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseControl : MonoBehaviour {
    /// <summary>
    /// 直线渲染器
    /// </summary>
    [SerializeField]
    private LineRenderer lineRenderer;
    /// <summary>
    /// 是否鼠标第一次按下
    /// </summary>
    private bool firstMouseDown = false;
    /// <summary>
    /// 是否鼠标持续按下
    /// </summary>
    private bool mouseDown = false;
    /// <summary>
    /// 保存的所有坐标
    /// </summary>
    private Vector3[] positions = new Vector3[10];
    /// <summary>
    /// 当前保存坐标的数量
    /// </summary>
    private int posCount = 0;
    /// <summary>
    /// 代表鼠标头的位置
    /// </summary>
    private Vector3 head;
    /// <summary>
    /// 代表上一帧的鼠标位置
    /// </summary>
    private Vector3 last;

    public AudioSource audioSource;
    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            firstMouseDown = true;
            mouseDown = true;
            audioSource.Play();
        }
        if (Input.GetMouseButtonUp(0))
        {
            mouseDown = false;
        }
        OnDrawLine();
        firstMouseDown = false;

    }


    private void OnDrawLine()
    {
        if (firstMouseDown)
        {
            posCount = 0;
            head = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            last = head;
        }
        if (mouseDown)
        {
            head = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector3.Distance(head,last)>0.01f)
            {
                //如果距离比较远了，就保存在数组里
                SavePosition(head);
                posCount++;
                OnRayCast(head);
            }
            last = head;
        }else
        {
            this.positions = new Vector3[10];
        }
        ChangePositions(positions);
    }
    private void OnRayCast(Vector3 worldPos)
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);
        Ray ray = Camera.main.ScreenPointToRay(screenPos);
        RaycastHit[] hits = Physics.RaycastAll(ray);
        for (int i=0;i<hits.Length;i++)
        {
            //Destroy(hits[i].collider.gameObject);
            //SendMessageOptions.DontRequireReceiver防止消息发送检测不到产生的错误
            hits[i].collider.gameObject.SendMessage("OnCut",SendMessageOptions.DontRequireReceiver);
        }
    }


    /// <summary>
    /// 保存坐标
    /// </summary>
    /// <param name="position"></param>
    private void SavePosition(Vector3 pos)
    {
        pos.z = 0;
        if (posCount<=9)
        {
            for (int i=posCount;i<10;i++)
            {
                positions[i] = pos;
            }
        }else
        {
            for (int i=0;i<9;i++)
            {
                positions[i] = positions[i + 1];
                positions[9] = pos;
            }
        }
    }
    /// <summary>
    /// 修改直线渲染器的坐标
    /// </summary>
    /// <param name="positions"></param>
    public void ChangePositions(Vector3[] positions)
    {
        lineRenderer.SetPositions(positions);
    }
}
