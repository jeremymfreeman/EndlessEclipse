using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
/*
public class Bullet : MonoBehaviour
{
    private Vector3 shootDir;

    public void Setup(Vector3 shootDir) {
        this.shootDir = shootDir;
        transform.eulerAngles = new Vector3(0, 0, UtilsClass.GetAngleFromVectorFloat(shootDir));
        Destroy(gameObject, 5f);
    }

    private void Update() {
        float moveSpeed = 100f;
        transform.position += shootDir * moveSpeed * Time.deltaTime;

       /* float hitdetectionSize = 3f;
        Target target = Target.GetClosest(transform.position, hitdetectionSize)
        if  (target != null) {
            target.Damage();
            Destroy(gameObject);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collider) {
        TargetJoint2D target = collider.GetComponent<Target>();
        if (target != null) {
            target.Damage();
            Destroy(gameObject);
        }
    }
}
*/