using System.Collections;
using UnityEngine;


public class ObjectMove : ObjectBase 

{

    [Header("目的地")]
    public Transform point;

    protected override IEnumerator Action()
    {
        GetComponent<Collider>().enabled = false;                                          //關閉碰撞器

        yield return new WaitForSeconds(delay);

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
}


