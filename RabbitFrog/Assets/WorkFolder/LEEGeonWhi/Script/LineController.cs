using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    //struct ScreenLimit
    //{
    //    public Vector2 Top_Left;   
    //    public Vector2 Top_Right;   
    //    public Vector2 Bottom_Left;   
    //    public Vector2 Bottom_Right;   
    //}


    private Vector2 startPos;
    private Vector2 endPos;

    [SerializeField]
    private GameObject line_prefab;
    private GameObject obj; //生成したprefabを変数に保存


    //private GameObject newLine;
    private LineRenderer lineRenderer; //生成したprefabのLinRenderer
    private BoxCollider2D boxCollider; //生成したprefabのboxCollider

    private bool Draw_able = false; //ink　mode
    private Vector2 start_screenLimit = new Vector2(100.0f, 100.0f); //線を書けるScreen範囲1 
    private Vector2 end_screenLimit = new Vector2(430.0f, 300.0f);   //線を書けるScreen範囲2

    [HideInInspector]
    public bool is_Drawing = false;　//今、線を書いてる中


    //[SerializeField]
    //private GameObject line_prefab;

    // Start is called before the first frame update
    void Start()
    {
        //ScreenLimit screenLimit;
        //screenLimit.Top_Left = new Vector2(100.0f, 300.0f);
        //screenLimit.Top_Right = new Vector2(430.0f, 300.0f);
        //screenLimit.Bottom_Left = new Vector2(100.0f, 100.0f);
        //screenLimit.Bottom_Right = new Vector2(430.0f, 100.0f);
    }

    // Update is called once per frame
    void Update()
    {



    }

    void LateUpdate()
    {
        if (Draw_able == false) { return; }
        DrawLine();
    }

    public void OnDraw_able()
    {
        Draw_able = !Draw_able;
    }

    /// <summary>
    /// 直線を書く
    /// </summary>
    public void DrawLine()
    {
        //マウスをクリックして線が始まる地点を決める
        if (Input.GetMouseButtonDown(0))
        {
            //SceenPositionをWorldPositionへ変換
            startPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                                                                  Input.mousePosition.y,
                                                                 -Camera.main.transform.position.z));

            if (!draw_able(Input.mousePosition)) return;
            is_Drawing = true;

            //newLine = new GameObject("Line");
            //lineRenderer = newLine.AddComponent<LineRenderer>();
            //lineRenderer.SetVertexCount(2);
            //lineRenderer.SetPosition(0, startPos);
            //=================================================

            //Line objを生成する
            obj = Instantiate(line_prefab, new Vector2(0, 0), Quaternion.identity);
            lineRenderer = obj.GetComponent<LineRenderer>();
            lineRenderer.SetVertexCount(2);
            lineRenderer.SetPosition(0, startPos); // start draw position
        }

        //マウスをドラッグして線が終わる地点を決める
        if (Input.GetMouseButton(0) && is_Drawing)
        {

            endPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                                                                Input.mousePosition.y,
                                                                -Camera.main.transform.position.z));

            if (!draw_able(Input.mousePosition)) return;
            //endPos = new Vector2(startPos.x, endPos.y);
            //lineRenderer.SetPosition(1, endPos);
            //==============================================
            endPos = new Vector2(startPos.x, endPos.y);
            lineRenderer.SetPosition(1, endPos); // // end draw position
        }

        //線を書きを終了する。
        if (Input.GetMouseButtonUp(0) && is_Drawing)
        {
            is_Drawing = false;

            //float pos_distance = Vector2.Distance(startPos, endPos);
            //boxCollider = newLine.AddComponent<BoxCollider2D>();
            //==============================================
            BoxCollider2D col = obj.AddComponent<BoxCollider2D>();　// 判定を追加
            col.isTrigger = true;
        }
    }

    /// <summary>
    /// 線が書けるエリアを判定
    /// </summary>
    /// <param name="mousePosition"></param>
    /// <returns></returns>
    private bool draw_able(Vector2 mousePosition)
    {

        if (mousePosition.x > start_screenLimit.x && mousePosition.x < end_screenLimit.x &&
            mousePosition.y > start_screenLimit.y && mousePosition.y < end_screenLimit.y)
        {
            return true;
        }
        //mousePosition.y > 100.0f && mousePosition.y < 300.0f;
        else
        {
            return false;
        }
    }



    //=============================================================================================
    /// <summary>
    /// Debug用(ゲーム実行には影響はなし)
    /// </summary>
    void OnDrawGizmosSelected()
    {
        // Draw a semitransparent blue cube at the transforms position

        Vector2 sPos = Camera.main.ScreenToWorldPoint(new Vector3(start_screenLimit.x,
                                                                  start_screenLimit.y,
                                                                  -Camera.main.transform.position.z));

        Vector2 ePos = Camera.main.ScreenToWorldPoint(new Vector3(end_screenLimit.x,
                                                                  end_screenLimit.y,
                                                                  -Camera.main.transform.position.z));

        Vector2 Top_Left = new Vector2(sPos.x,ePos.y);   
        Vector2 Top_Right = ePos;   
        Vector2 Bottom_Left = sPos;   
        Vector2 Bottom_Right = new Vector2(ePos.x, sPos.y);    

        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawLine(Top_Left, Top_Right);
        Gizmos.DrawLine(Top_Right, Bottom_Right);
        Gizmos.DrawLine(Bottom_Right, Bottom_Left);
        Gizmos.DrawLine(Bottom_Left, Top_Left);

        //Gizmos.DrawCube(transform.position, Pos);
        //Gizmos.DrawCube(transform.position, new Vector3(10, 10, 1));
    }
}
