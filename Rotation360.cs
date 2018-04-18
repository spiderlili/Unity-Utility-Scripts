//rotates a GameObject from 0 to 180 degrees and then stop

using UnityEngine;
using System.Collections;

public class Rotation360 : MonoBehaviour{
  public float angle = 180.0f;
  public float speed = 10f;

  public void Start(){
    StartCoroutine("Rotate");
  }

  public IEnumerator Rotate(){
    Vector3 axis = new Vector3(0.0f, 1.0f, 0.0f);
    float rotAngle = 0.0f;
    float totalRot = 0.0f;

    Quaternion startRot = transform.rotation;

    while (totalRot < 1.0f){
      rotAngle = Mathf.SmoothStep(0.0f, 1.0f, speed * Time.deltaTime);
      totalRot += rotAngle;
      transform.Rotate(axis, rotAngle * angle);
      yield return 0;
      }
    transform.rotation = Quaternion.Euler(new Vector3(startRot.eulerAngles.x, startRot.eulerAngles.y + angle, startRot.eulerAngles.z));
}
}
