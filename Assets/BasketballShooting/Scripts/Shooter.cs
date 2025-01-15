using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Shooter : MonoBehaviour {

    public XRController xrController;  // 手柄控制器
    public GameObject ballPrefab;      // 篮球预制体
    public Transform shotPoint;        // 投掷起点

    public float shotPowerMin = 3.0f;  // 最小投掷力度
    public float shotPowerMax = 12.0f; // 最大投掷力度
    public float torque = 30.0f;       // 投掷扭矩

    private float shotPower;           // 当前投掷力度
    private Vector3 direction;         // 当前投掷方向

    void Start() {
        shotPower = shotPowerMin;
        direction = Vector3.zero;
    }

    void Update() {
        HandleInput();
    }

    void HandleInput() {
        // 检测鼠标左键按下
        if (Input.GetMouseButtonDown(1)) {
            CreateBall();
        }
    }

    void ShootBall(GameObject ball) {
        if (ball == null) {
            Debug.LogError("Ball is null. Did you forget to call CreateBall?");
            return;
        }

        Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
        if (ballRigidbody == null) {
            Debug.LogError("Rigidbody component is missing on ball!");
            return;
        }

        // 投掷逻辑
        if (xrController.inputDevice.TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 deviceVelocity)) {
            shotPower = Mathf.Clamp(deviceVelocity.magnitude, shotPowerMin, shotPowerMax);
            direction = xrController.transform.rotation * Vector3.forward;

            // 设置篮球速度和旋转
            ballRigidbody.velocity = direction * shotPower;
            ballRigidbody.AddTorque(-direction * torque);

            Debug.Log($"Ball thrown with power {shotPower} and direction {direction}");
        }

        ShotBall shotBall = ball.GetComponent<ShotBall>();
        if (shotBall != null) {
            shotBall.ChangeActive();
        }
    }

    void CreateBall() {
        GameObject newBall = Instantiate(ballPrefab);

        // 初始化刚体
        Rigidbody ballRigidbody = newBall.GetComponent<Rigidbody>();
        if (ballRigidbody == null) {
            Debug.LogError("Rigidbody component is missing on ballPrefab!");
            return;
        }

        // 检查 ShotBall 组件
        ShotBall shotBall = newBall.GetComponent<ShotBall>();
        if (shotBall == null) {
            Debug.LogError("ShotBall component is missing on ballPrefab!");
            return;
        }

        // 设置篮球初始状态
        newBall.transform.position = shotPoint.position;
        newBall.transform.rotation = shotPoint.rotation;
        ballRigidbody.velocity = Vector3.zero;
        ballRigidbody.useGravity = true;

        // 保持激活状态
        shotBall.ChangeActive();

        Debug.Log("Ball successfully created with Rigidbody and ShotBall components.");
    }

    public float GetShotPower() {
        return shotPower;
    }

    public Vector3 GetShotDirection() {
        return direction;
    }

    void FixedUpdate() {
        // 不再自动生成篮球，改用手动触发
    }
}



