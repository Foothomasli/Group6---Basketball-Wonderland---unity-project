﻿// using UnityEngine;
// using System.Collections;

// public class GoalHoop : MonoBehaviour {

// 	// Use this for initialization
// 	void Start () {

// 		float RR = 1.046f;
// 		Vector3 RC = new Vector3 (0.088f, 2.874f, 1.109f);

// 		for (int i=0; i<360; i+=30) {
// 			float rad = (i*Mathf.PI)/180.0f;
// 			SphereCollider sc = (SphereCollider)this.gameObject.AddComponent<SphereCollider>();
// 			sc.center = new Vector3 (RC.x + RR*Mathf.Sin(rad), RC.y, RC.z+ RR*Mathf.Cos(rad));
// 			sc.radius = 0.042f;
// 		}

// 	}
	
// 	// Update is called once per frame
// 	void Update () {
	
// 	}
// }

using UnityEngine;
using System.Collections;

public class GoalHoop : MonoBehaviour {

    // 初始化时创建篮球框的碰撞器
    void Start() {
        float hoopRadius = 1.046f; // 圆形半径
        Vector3 hoopCenter = new Vector3(0.088f, 2.874f, 1.109f); // 圆心位置

        for (int i = 0; i < 360; i += 30) {
            float angleRad = (i * Mathf.PI) / 180.0f;
            SphereCollider sc = this.gameObject.AddComponent<SphereCollider>();
            sc.center = new Vector3(
                hoopCenter.x + hoopRadius * Mathf.Sin(angleRad),
                hoopCenter.y,
                hoopCenter.z + hoopRadius * Mathf.Cos(angleRad)
            );
            sc.radius = 0.042f;
        }
    }
}
