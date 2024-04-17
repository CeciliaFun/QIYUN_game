using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    // Start is called before the first frame update
    Transform HeroTransform;
    [SerializeField] float xDistance;
    [SerializeField] float yDistance;
    [SerializeField] float XSmooth;
    [SerializeField] float YSmooth;
    [SerializeField] Vector2 maxX_and_Y = new Vector2(8, 6);
    [SerializeField] Vector2 minX_and_Y = new Vector2(-8, -6);

    private void Awake()
    {
        HeroTransform = GameObject.Find("Ball").transform;
        //HeroTransform = GameObject.FindGameObjectWithTag("Player").transform;

    }

    bool NeedMoveX()
    {
        return Mathf.Abs(transform.position.x - HeroTransform.position.x) > xDistance;
    }

    bool NeedMoveY()
    {
        return Mathf.Abs(transform.position.y - HeroTransform.position.y) > yDistance;
    }

    private void FixedUpdate()
    {
        trackPlayer();
    }

    void trackPlayer()
    {
        float CamNew_x = transform.position.x;//x方向必须先保存，避免移动后失去原位置
        float CamNew_y = transform.position.y;
        if (NeedMoveX())
        {
            CamNew_x = Mathf.Lerp(transform.position.x, HeroTransform.position.x, XSmooth * Time.deltaTime);
            CamNew_x = Mathf.Clamp(CamNew_x, minX_and_Y.x, maxX_and_Y.x);//限制函数，如果小于最小值则返回最小值，如果大于最大值则返回最大值

        }
        if (NeedMoveY())
        {
            CamNew_y = Mathf.Lerp(transform.position.y, HeroTransform.position.y, YSmooth * Time.deltaTime);
            CamNew_y = Mathf.Clamp(CamNew_y, minX_and_Y.y, maxX_and_Y.y);
        }
        transform.position = new Vector3(CamNew_x, CamNew_y, transform.position.z);
    }
}