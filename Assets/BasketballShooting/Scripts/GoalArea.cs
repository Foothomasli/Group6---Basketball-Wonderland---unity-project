using UnityEngine;
using System.Collections;

public class GoalArea : MonoBehaviour {

    public ParticleSystem psStar;  // 命中时播放的粒子特效

    public int score { get; private set; } // 当前得分

    // 初始化
    void Start() {
        score = 0;
    }

    // 检测触发器
    void OnTriggerEnter(Collider other) {
        ShotBall sb = other.GetComponent<ShotBall>();
        if (sb != null && sb.isActive) {
            // 命中得分
            score++;
            psStar.Play();
        }
    }

    // 重置得分
public void ResetScore() {
    score = 0;
}

}


