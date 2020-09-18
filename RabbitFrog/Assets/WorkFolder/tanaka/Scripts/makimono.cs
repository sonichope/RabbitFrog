using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using UnityEngine;

public class makimono : MonoBehaviour
{
    [SerializeField] GameObject Makia;
    //[SerializeField] GameObject pepar;
    [SerializeField] GameObject Makib;
    //public bool makiFrag = true;
    //[SerializeField] GameObject Peperb;

    /*やりたい動き
      巻物がタップされた時のアニメーションが終了した時
      下の OpenMakimono(CloseMakimono) の動きをする
      OpenMakimono が実行される時 pepar のアニメーションを実行する
      「この時巻物がタップされる度に pepar のアニメーションを繰り返し実行する」
      タップされた巻物を画面の中央の方に持ってくる
    　2つの巻物のpositionを入れ替える時(動きをプランナーに要確認する)
    　2つの巻物を回転させるように入れ替える動きをつける(太鼓の達人の選択するところのように)*/

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenMakimono()
    {
        //Makia.transform.localPosition = new Vector2(260, 0);
        //Makib.transform.localPosition = new Vector2(350, 0);
        //
        if (Makia.transform.localPosition.x > 350)
        {
            Makia.transform.localScale = new Vector2(1, 1.25f);
            Makib.transform.localScale = new Vector2(1, 1);
            Makia.transform.Translate(Vector2.right * 0.1f);
            Makib.transform.Translate(Vector2.left * 0.1f);
        }
    }

    public void CloseMakimono()
    {
        //.transform.localPosition = new Vector2(260, 0);
        //Makia.transform.localPosition = new Vector2(350, 0);
        if (Makib.transform.localPosition.y > 350)
        {
            Makib.transform.localScale = new Vector2(1, 1.25f);
            Makia.transform.localScale = new Vector2(1, 1);
            Makia.transform.Translate(Vector2.left * 0.1f);
            Makib.transform.Translate(Vector2.right * 0.1f);
        }
    }

    void isCanvasEnable()
    {

    }
}
