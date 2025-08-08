using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //conePrefabを入れる
    public GameObject conePrefab;
    //スタート地点
    private int startPos = 80;
    //ゴール地点
    private int goalPos = 360;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    //当たったオブジェクトのタグがアイテム生成のタグなら
    //アイテムを生成する

    void OnTriggerEnter(Collider other)
    {
        //ObjectMakeがItemGeneratorタグにぶつかったら
        if (other.gameObject.CompareTag("ItemGenerator"))
        {
            //生成のためのZ軸を取得する
            float posZ = other.transform.position.z;
            
            //どのアイテムを出すのかランダムに設定
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                //コーンをx軸方向に一直線に生成
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab);

                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, posZ);
                }
            }
            else
            {
                //レーンごとにアイテムを生成
                for (int j = -1; j <= 1; j++)
                {
                    //アイテムの種類を決める
                    int item = Random.Range(1, 11);
                    //アイテムを置くz座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);
                    //60%コイン配置:30％車配置:10％何もなし
                    if (1 <= item && item <= 6)
                    {
                        //コインを生成
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, posZ + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, posZ + offsetZ);
                    }
                }
            }
        }

    }





    // Update is called once per frame
    void Update()
    { 

    }

    
}
