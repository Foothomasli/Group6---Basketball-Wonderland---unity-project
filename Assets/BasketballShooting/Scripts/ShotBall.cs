/* ShotBall.cs
  version 1.0 - August 7, 2015

  Copyright (C) 2015 Wasabi Applications Inc.
   http://www.wasabi-applications.co.jp/
*/

// using UnityEngine;
// using System.Collections;

// public class ShotBall : MonoBehaviour {


// 	public bool isActive {get; private set;}	


// 	public void ChangeActive () {
// 		isActive = true;
// 	}
// }


using UnityEngine;

public class ShotBall : MonoBehaviour {

    public bool isActive { get; private set; } // 篮球的激活状态

    // 改变激活状态
    public void ChangeActive() {
        isActive = true;
    }
}

