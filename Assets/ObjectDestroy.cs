using UnityEngine;

public class ObjectDestroy : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        //オブジェクトを削除
        Debug.Log(other.gameObject.name );
        Destroy(other.gameObject);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
