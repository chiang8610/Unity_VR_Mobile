using UnityEngine;
using System.Collections;


public class ObjectRotate : ObjectBase
{
    [Header("旋轉角度"), Range(-360, 360)]
    public float turn = 90;
    

    protected override IEnumerator Action()
    {
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(delay);

        aud.PlayOneShot(sound, volume);

        Quaternion angleA = transform.rotation;
        Quaternion angleB = Quaternion.Euler(0, turn, 0);

        while(angleA!=angleB)
        {
            angleA = Quaternion.Lerp(angleA, angleB, speed * Time.deltaTime);
            transform.rotation = angleA;
            yield return null;
        }
    }
}
