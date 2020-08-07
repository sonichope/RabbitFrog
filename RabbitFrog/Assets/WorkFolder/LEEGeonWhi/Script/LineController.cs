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
    private Vector2 centwePos;

    [SerializeField]
    private List<Vector3> Points = new List<Vector3>();

    private List<float> Points_X = new List<float>();
    private List<float> Points_Y = new List<float>();

    [SerializeField]
    private GameObject Drawing_obj;
    [SerializeField]
    private GameObject line_prefab;
    private GameObject obj; //生成したprefabを変数に保存
    private float lineLength; //線の長さ
    private float Angle;

    [SerializeField]
    private GameObject test_obj;
    [SerializeField]
    private float circumference  = 0;
    [SerializeField]
    private float radius = 0;
    [SerializeField]
    private Vector2 circle_center;
    private Vector2 tempPos;


    //private GameObject newLine;
    private LineRenderer lineRenderer; //生成したprefabのLinRenderer
    private BoxCollider2D boxCollider; //生成したprefabのboxCollider

    private bool Draw_able = false; //ink　mode

    [SerializeField]
    private Vector2 start_screenLimit = new Vector2(100.0f, 100.0f); //線を書けるScreen範囲1 
    [SerializeField]
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

        Drawing_obj.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        //if (Draw_able == false) { return; }
        DrawLine();
    }

    public void OnDraw_able()
    {
        Draw_able = !Draw_able;
    }

    /// <summary>
    /// 直線を書く
    /// </summary>
    private void DrawLine()
    {
        //マウスをクリックして線が始まる地点を決める
        if (Input.GetMouseButtonDown(0))
        {
            //StartCoroutine(DrawableTime());

            //SceenPositionをWorldPositionへ変換
            startPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                                                                  Input.mousePosition.y,
                                                                 -Camera.main.transform.position.z));
            //i = 0;
            if (!draw_able(Input.mousePosition)) return;
            is_Drawing = true;
           
            //newLine = new GameObject("Line");
            //lineRenderer = newLine.AddComponent<LineRenderer>();
            //lineRenderer.SetVertexCount(2);
            //lineRenderer.SetPosition(0, startPos);
            //=================================================

            //2020.08.03
            //Line objを生成する
            //obj = Instantiate(line_prefab, new Vector2(0, 0), Quaternion.identity);
            //lineRenderer = obj.GetComponent<LineRenderer>();
            //lineRenderer.SetVertexCount(2);
            //lineRenderer.SetPosition(0, startPos); // start draw position

            Drawing_obj.SetActive(true);
            Drawing_obj.transform.position = startPos;

            Points.RemoveRange(0, Points.Count);
            circumference  = 0;
            radius = 0;
        }



        //マウスをドラッグして線が終わる地点を決める
        if (Input.GetMouseButton(0) && is_Drawing)
        {

            endPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                                                                Input.mousePosition.y,
                                                                -Camera.main.transform.position.z));

            centwePos = endPos;
            //linePoints[i] = endPos;

            //i++;
            //i %= 360;

            Points.Add(endPos);
            Points_X.Add(endPos.x);
            Points_Y.Add(endPos.y);

            if (!draw_able(Input.mousePosition)) return;

            //endPos = new Vector2(startPos.x, endPos.y);
            //lineRenderer.SetPosition(1, endPos);
            //==============================================
            //endPos = new Vector2(startPos.x, endPos.y);

            //2020.08.03
            //endPos = new Vector2(endPos.x, endPos.y);
            //lineRenderer.SetPosition(1, endPos); // // end draw position

            Drawing_obj.transform.position = endPos;

            //===========================円関連処理               
        }

        //線を書きを終了する。
        if (Input.GetMouseButtonUp(0) && is_Drawing)
        {
            is_Drawing = false;
            Drawing_obj.SetActive(false);

            //直線生成
            if (GetAngle(startPos, endPos) >= 80 && GetAngle(startPos, endPos) <= 100)
            {
                obj = Instantiate(line_prefab, new Vector2(0, 0), Quaternion.identity);
                lineRenderer = obj.GetComponent<LineRenderer>();
                lineRenderer.SetVertexCount(2);

                lineRenderer.SetPosition(0, startPos); // start draw position

                endPos = new Vector2(startPos.x,
                                    Drawing_obj.transform.position.y);
                lineRenderer.SetPosition(1, endPos); // // end draw position

                BoxCollider2D col = obj.AddComponent<BoxCollider2D>(); // 判定を追加
                col.isTrigger = true;

                lineLength = Mathf.Abs(endPos.y - startPos.y);
                obj.GetComponent<Line>().lineLength = lineLength; // 
                obj.GetComponent<Line>().HP = 1 + 0.2f * (lineLength - 1); // HPを初期化
            }

            // draw circle
            else
            {
               
                for (int i=0; i<Points.Count - 1; i++)
                {
                    circumference  += Vector3.Distance(Points[i], Points[i+1]);
                }
                radius = circumference / 6.28f;
                circle_center = new Vector2(Points[0].x, Points[0].y);
                var obj2  = Instantiate(test_obj, circle_center, Quaternion.identity);
                obj2.transform.localScale = new Vector3(radius,radius,1);
            }

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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    float GetAngle(Vector2 start, Vector2 end)
    {
        Vector2 v2 = end - start;
        return Mathf.Abs(Mathf.Atan2(v2.y, v2.x) * Mathf.Rad2Deg);
    }

   IEnumerator DrawableTime()
    {
        yield return new WaitForSeconds(5.0f);
        is_Drawing = false;
    }

}
