using UnityEngine;
using System.Collections;


//要求元件(類型())
//套用腳本時會執行
[RequireComponent(typeof(AudioSource))]
public class ObjectMove : MonoBehaviour
{
    [Header("移動速度"), Range(1, 500)]
    public float speed = 10;
    [Header("目的地")]
    public Transform point;
    [Header("音效")]
    public AudioClip sound;
    [Header("音量")]
    public float volume = 1;

    /// <summary>
    /// 喇叭
    /// </summary>
    private AudioSource aud;

    private void Awake()
    {
        aud = GetComponent<AudioSource>();
    }

    private IEnumerable Move()
    {

        GetComponent<Collider>().enabled = false;                                          //關閉碰撞器

        aud.PlayOneShot(sound, volume);                                                          // 播放聲音
        Vector3 posA = transform.position;                                                         //A 點: 本物件(自己)
        Vector3 posB = point.position;                                                                //B 點: 目的地

        while (posA != posB)                                                                               // 當 A 點 不等於 B 點
            {
            posA = Vector3.Lerp(posA, posB, speed * Time.deltaTime);             //插值(A 點， B 點，速度 * 一個影格的時間)
            transform.position = posA;                                                                  //本物件的座標 = A
            yield return null;                                                                                  //等待


            }

      

    }

    public void  StartMove()
    {
        StartCoroutine ( Move ( ));
    }
}
