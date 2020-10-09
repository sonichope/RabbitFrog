using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UIElements;

public class LineController : MonoBehaviour
{

    private Vector2 startPos;
    private Vector2 endPos;
    private Vector2 tempPos;
    private Vector2 circle_center;

    [SerializeField]
    private float width = 0.5f;

    [SerializeField]
    private List<Vector2> Points = new List<Vector2>(); //マウス移動経路　
    [SerializeField]
    private List<Vector2> Points_X = new List<Vector2>(); //Pointsをposition.xを基準にしてlist整列   
    [SerializeField]
    private List<Vector2> Points_Y = new List<Vector2>(); //Pointsをposition.Yを基準にしてlist整列

    [SerializeField]
    private GameObject Drawing_obj;
    [SerializeField]
    private GameObject line_prefab;
    [SerializeField]
    private GameObject Cube;


    private GameObject obj; //生成したprefabを変数に保存
    private GameObject mouce_obj;

    private float lineLength; //線の長さ
    private float Angle; //角度

    [SerializeField]
    private GameObject circle;
    private float circumference = 0;//円の長さ
    private float radius = 0;//円の半径

    [SerializeField]
    private GameObject Triangle;

    [SerializeField]
    private List<Vector3> Points_normal = new List<Vector3>();
    [SerializeField]
    private float MaxYPos = 0;

    private LineRenderer lineRenderer; //生成したprefabのLinRenderer
    private LineRenderer Pointer_linRenderer;
    private LineRenderer Tri_linRenderer;

    static public bool is_inkMode = false; //インクモード

    [SerializeField]
    private Vector2 start_screenLimit = new Vector2(-5.0f, -2.5f); //線を書けるScreen範囲1 
    [SerializeField]
    private Vector2 end_screenLimit = new Vector2(5.0f, 5.0f);   //線を書けるScreen範囲2

    private bool is_Drawing = false; //今、線を書いてる中

    void Update()
    {
        if (is_inkMode == false || InkAmout.inkChack() == false) return;
        DrawLine();
    }

    public void OnIsDraw()
    {
        is_inkMode = !is_inkMode;
        //if(is_inkMode) test.material.SetFloat("_Width", 0);
        //if(!is_inkMode) test.material.SetFloat("_Width", 1);
;    }

    private void DrawLine()
    {
        //マウスをクリックして線が始まる地点を決める
        if (Input.GetMouseButtonDown(0))
        {


            //SceenPositionをWorldPositionへ変換
            startPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                                                                  Input.mousePosition.y,
                                                                 -Camera.main.transform.position.z));


            if (!draw_able()) return;
            is_Drawing = true;

            mouce_obj = Instantiate(Drawing_obj, startPos, Quaternion.identity);


            //list初期化
            //----------------------------------------
            Points.RemoveRange(0, Points.Count);
            Points_X.RemoveRange(0, Points_X.Count);
            Points_Y.RemoveRange(0, Points_Y.Count);
            Points_normal.RemoveRange(0, Points_normal.Count);

            //----------------------------------------

            //半径、長さ初期化
            //----------------------------------------
            circumference = 0;
            radius = 0;
            //----------------------------------------
        }

        //マウスをドラッグして線が終わる地点を決める
        if (Input.GetMouseButton(0) && is_Drawing)
        {

            endPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                                                                Input.mousePosition.y,
                                                                -Camera.main.transform.position.z));

            if (!draw_able()) return;
            //マウスを動かないとlistの追加をしない
            if (Vector2.Distance(tempPos, endPos) < 0.5f) return;

            Points.Add(endPos);
            Points_X.Add(endPos);
            Points_Y.Add(endPos);

            Drawing_obj.transform.position = endPos;
            mouce_obj.transform.position = endPos;
            tempPos = endPos;

        }

        //線を書きを終了する。
        if (Input.GetMouseButtonUp(0) && is_Drawing)
        {
            Destroy(mouce_obj);

            is_Drawing = false;

            //--------------------
            Points_X.Sort((s1, s2) => s1.x.CompareTo(s2.x)); //position.xを基準にして配列整列
            Points_Y.Sort((s1, s2) => s1.y.CompareTo(s2.y)); //position.ｙを基準にして配列整列
                                                             //--------------------
                                                             //Debug.Log(GetAngle(startPos, Points_Y[Points_Y.Count - 1]) +"===" +GetAngle(Points_Y[Points_Y.Count - 1], endPos));
                                                             //Debug.Log(GetAngle(startPos, endPos));


            Chack_Point_Normal();
            //直線生成

            //if (Mathf.Abs(GetAngle(startPos, endPos)) >= 80 && Mathf.Abs(GetAngle(startPos, endPos)) <= 100 && Points.Count < 10)
            if (Chack_Line() && Points.Count < 10)
            {
                //obj = Instantiate(line_prefab, new Vector2(0, 0), Quaternion.identity);
                //lineRenderer = obj.GetComponent<LineRenderer>();
                //lineRenderer.SetVertexCount(2);

                //lineRenderer.SetPosition(0, startPos); // start draw position

                //endPos = new Vector2(startPos.x,
                //                    Drawing_obj.transform.position.y);
                //lineRenderer.SetPosition(1, endPos); // // end draw position
                //lineRenderer.SetWidth(width, width);;

                //lineLength = Mathf.Abs(endPos.y - startPos.y);
                //obj.GetComponent<Line>().lineLength = lineLength; // 
                //obj.GetComponent<Line>().HP = 1 + 0.2f * (lineLength - 1); // HPを初期化

                //===============================================

                List<Vector2> respawn = new List<Vector2>();
                respawn.Add(startPos);

                Vector3 Dir = Vector3.Normalize(startPos - endPos);


                //var test = Instantiate(new GameObject(), startPos, Quaternion.identity);
                GameObject test = new GameObject();
                test.name = "WallManager";

               for (int i = 0; i < Points.Count - 1; i++)
                {
                    obj = Instantiate(Cube, startPos, Quaternion.identity);
                    obj.transform.parent = test.transform;
                    if(Dir.y < 0)
                    {
                        startPos.x -= 0.2f;
                        startPos.y += 0.3f;
                    }
                    
                    else if (Dir.y > 0)
                    {
                        startPos.x += 0.2f;
                        startPos.y -= 0.3f;
                    }
                }

            }

            //三角形を生成
            else if(Chack_Traiangle(startPos, Points_Y[Points_Y.Count - 1],endPos) && Points.Count < 10)
            {
                float Tri_Height = Mathf.Abs((Points_Y[Points_Y.Count - 1].y - startPos.y));
                float Tri_Width = Mathf.Abs((endPos.x - startPos.x));
                float Tri_area = Tri_Height * Tri_Width / 2;

                Vector3 Center = Vector3.Lerp(startPos, endPos, 0.5f);
                //Center.y += Tri_Height / 2;
                var Tri_obj = Instantiate(Triangle, new Vector2(0,0) , Quaternion.identity);
                Tri_obj.GetComponent<Triangle>().HP = 10.0f;
                
                Tri_linRenderer = Tri_obj.GetComponent<LineRenderer>();
                //Tri_obj.transform.localScale = new Vector3(Tri_area, Tri_area, 1);
                Tri_linRenderer.SetPosition(0, Center);
                Center.y += Tri_Height;
                Tri_linRenderer.SetPosition(1, Center);
            }

            // draw circle
            else if(Chack_Circle())
            {
                //float distance = (endPos - startPos).magnitude;
                //Debug.Log(dis);
                //===========================================================================
                //if (Vector3.Distance(Points[0], Points[Points.Count - 1]) > 5.0f) return;
                //if (Vector2.Distance(Points_X[0], Points_X[Points.Count - 1]) > 10.0f ||
                //    Vector2.Distance(Points_Y[0], Points_Y[Points.Count - 1]) > 10.0f) return;
                //===========================================================================

                if (Points.Count < 10 || Points.Count > 20) return;

                //円の長さを計算する
                for (int i = 0; i < Points.Count - 1; i++)
                {
                    circumference += Vector3.Distance(Points[i], Points[i + 1]);
                }
                //半径を計算する
                radius = circumference / 6.28f;
         
                circle_center = new Vector2(
                                             (Points_Y[0].x + Points_Y[Points_Y.Count - 1].x) / 2 ,
                                             (Points_X[0].y + Points_X[Points_X.Count - 1].y) / 2
                                            );
                var obj2 = Instantiate(circle, circle_center, Quaternion.identity);
                obj2.transform.localScale = new Vector3(radius, radius, 1);

                obj2.GetComponent<Circle>().circumference = circumference;
                obj2.GetComponent<Circle>().HP = 1 - (circumference - 1) * 0.2f;
                //BoxCollider2D col = obj2.AddComponent<BoxCollider2D>(); // 判定を追加
                //col.isTrigger = true;
            }

            //InkAmout.decrease_Gauge(0.1f);

        }

    }

    /// <summary>
    /// 線が書けるエリアを判定
    /// </summary>
    /// <param name="mousePosition"></param>
    /// <returns></returns>
    private bool draw_able()
    {
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (pos.x > start_screenLimit.x && pos.x < end_screenLimit.x &&
            pos.y > start_screenLimit.y && pos.y < end_screenLimit.y)
        {
            return true;
        }
        //mousePosition.y > 100.0f && mousePosition.y < 300.0f;
        else
        {
            return false;
        }
    }
    
    /// <summary>
    /// 三角形を判定
    /// </summary>
    /// <param name="startPos"></param>
    /// <param name="MaxY_Pos"></param>
    /// <param name="endPos"></param>
    /// <returns></returns>
    bool Chack_Traiangle(Vector2 startPos, Vector2 MaxY_Pos, Vector2 endPos)
    {
        //if (Mathf.Abs(startPos.y - endPos.y) <= 0) return false;
        
        if (MaxY_Pos.y - startPos.y <= 0 && GetAngle(startPos,endPos) > 0) return false;
        Vector3 Dir_Chack = Vector3.Normalize(MaxY_Pos - startPos);
        if (Dir_Chack.y <= 0) return false;

            if (GetAngle(startPos, MaxY_Pos) <= 70 || GetAngle(startPos, MaxY_Pos) >= 110)
        {
            if (GetAngle(startPos, MaxY_Pos) < 0) return false;

            if (GetAngle(MaxY_Pos, endPos) >= -80 || GetAngle(MaxY_Pos, endPos) <= -120)
            {
                if (GetAngle(MaxY_Pos, endPos) > 0) return false;
                return true; 
            }
        }
        return false;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    bool Chack_Line()
    {
        for(int i = 0; i < Points.Count - 1; i++)
        {
            if(Mathf.Abs(GetAngle(Points[i], Points[i + 1])) <= 80 || Mathf.Abs(GetAngle(startPos, endPos)) >= 100)
            {
                return false;
            }
        }
        return true;
    }

    bool Chack_Circle()
    {
        bool ChangeDir_X = false;
        bool ChangeDir_Y = false;
        float temp = 0;

        for (int i = 0; i < Points_normal.Count - 1; i++)
        {
            if (Points_normal[i].x < 0 && temp > 0) ChangeDir_X = true;
            if (Points_normal[i].x > 0 && temp < 0) ChangeDir_X = true;
            temp = Points_normal[i].x;
        }


        for (int i = 0; i < Points_normal.Count - 1; i++)
        {
            if (Points_normal[i].y - Points_normal[i + 1].y < 0 && temp > 0) ChangeDir_Y = true;
            if (Points_normal[i].y - Points_normal[i + 1].y > 0 && temp < 0) ChangeDir_Y = true;
            temp = Points_normal[i].y - Points_normal[i + 1].y;
        }

        if(ChangeDir_X && ChangeDir_Y)
        {
            return true;
        }

        else
        {
            return false;
        }
    }


    /// <summary>
    /// 
    /// </summary>
    void Chack_Point_Normal()
    {
        float temp = 0;
        for (int i = 0; i < Points.Count - 1; i++)
        {   
            Points_normal.Add(Vector3.Normalize(Points[i + 1] - Points[i]));
            if (Points_normal[i].y < 0 && temp > 0)
            {
                MaxYPos = Points[i].y;
                //return;
            }
            temp = Points_normal[i].y;
        }
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
        return Mathf.Atan2(v2.y, v2.x) * Mathf.Rad2Deg;
    }

    //=============================================================================================
    /// <summary>
    /// Debug用(ゲーム実行には影響はなし)
    /// </summary>
    void OnDrawGizmosSelected()
    {
        // Draw a semitransparent blue cube at the transforms position

        Vector2 sPos = new Vector3(start_screenLimit.x, start_screenLimit.y, -Camera.main.transform.position.z);
        Vector2 ePos = new Vector3(end_screenLimit.x, end_screenLimit.y, -Camera.main.transform.position.z);

        Vector2 Top_Left = new Vector2(sPos.x, ePos.y);
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