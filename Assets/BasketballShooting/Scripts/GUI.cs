// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.SceneManagement;
// using System;
// using System.Collections;
// using System.Collections.Generic;

// public class GUI : MonoBehaviour
// {
//     public Shooter shooter;
//     public GoalArea goalArea;

//     public Text textScore;
//     public Text textSavedScores; 

//     private List<string> savedScores = new List<string>(); 

//     void Start()
//     {
//         if (shooter == null)
//         {
//             shooter = FindObjectOfType<Shooter>();
//         }
//         if (goalArea == null)
//         {
//             goalArea = FindObjectOfType<GoalArea>();
//         }
//         if (textScore == null || textSavedScores == null)
//         {
//             Debug.LogError("UI Text components are not assigned in the Inspector!");
//         }


//     //清除保存的历史记录
//     if (PlayerPrefs.HasKey("SavedScores"))
//     {
//         PlayerPrefs.DeleteKey("SavedScores");
//         PlayerPrefs.Save();
//     }



//         // 初始化保存的得分记录
//         if (PlayerPrefs.HasKey("SavedScores"))
//         {
//             string savedData = PlayerPrefs.GetString("SavedScores");
//             if (!string.IsNullOrEmpty(savedData))
//             {
//                 savedScores = new List<string>(savedData.Split('|')); // 按 | 分割保存的多条记录
//             }
//         }

//         // 如果没有保存记录，显示默认信息
//         UpdateSavedScoresDisplay();
//     }

//     void Update()
//     {
//         if (shooter == null || goalArea == null) return;

//         // 更新得分显示
//         textScore.text = goalArea.score.ToString();
//     }

//     public void PushedResetButton()
//     {
//         if (goalArea != null)
//         {
//             goalArea.ResetScore(); // 重置逻辑得分
//         }
//         textScore.text = "0"; // 更新 UI 显示
//     }

//     public void PushedRestoreButton()
//     {
//         // 开始延迟保存的协程
//         StartCoroutine(SaveScoreAfterDelay(10f));
//     }

//     private IEnumerator SaveScoreAfterDelay(float delay)
//     {
//         // 等待指定时间
//         yield return new WaitForSeconds(delay);

//         // 获取当前日期和得分
//         string currentDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
//         int score = goalArea.score;
//         string rating = GetScoreRating(score); // 获取评价

//         // 构造记录内容
//         string scoreRecord = $"Retention date： {currentDate}        Score： {score}        Evaluation： {rating}";

//         // 避免重复保存
//         if (!savedScores.Contains(scoreRecord))
//         {
//             savedScores.Add(scoreRecord);

//             // 更新显示
//             UpdateSavedScoresDisplay();

//             // 保存到本地存储
//             string savedData = string.Join("|", savedScores); // 用 | 分隔每条记录
//             PlayerPrefs.SetString("SavedScores", savedData);
//             PlayerPrefs.Save();

//             Debug.Log($"Score saved after {delay} seconds: {scoreRecord}");
//         }
//     }

//     private string GetScoreRating(int score)
//     {
//         if (score < 5)
//         {
//             return "Normal";
//         }
//         else if (score <= 10)
//         {
//             return "Excellence";
//         }
//         else
//         {
//             return "Perfect";
//         }
//     }

//     private void UpdateSavedScoresDisplay()
//     {
//         if (savedScores.Count == 0)
//         {
//             textSavedScores.text = "No saved scores";
//         }
//         else
//         {
//             // 每条记录换行显示
//             textSavedScores.text = string.Join("\n", savedScores);
//         }
//     }
// }

// using UnityEngine;
// using UnityEngine.UI;
// using System;
// using System.Collections;
// using System.Collections.Generic;

// public class GUI : MonoBehaviour
// {
//     public Shooter shooter;
//     public GoalArea goalArea;

//     public Text textScore;
//     public Text textSavedScores;

//     private List<string> savedScores = new List<string>();

//     void Start()
//     {
//         if (shooter == null)
//         {
//             shooter = FindObjectOfType<Shooter>();
//         }
//         if (goalArea == null)
//         {
//             goalArea = FindObjectOfType<GoalArea>();
//         }
//         if (textScore == null || textSavedScores == null)
//         {
//             Debug.LogError("UI components are not assigned in the Inspector!");
//         }

//         // 清除保存的历史记录
//         if (PlayerPrefs.HasKey("SavedScores"))
//         {
//             PlayerPrefs.DeleteKey("SavedScores");
//             PlayerPrefs.Save();
//         }

//         // 初始化保存的得分记录
//         if (PlayerPrefs.HasKey("SavedScores"))
//         {
//             string savedData = PlayerPrefs.GetString("SavedScores");
//             if (!string.IsNullOrEmpty(savedData))
//             {
//                 savedScores = new List<string>(savedData.Split('|')); // 按 | 分割保存的多条记录
//             }
//         }

//         // 如果没有保存记录，显示默认信息
//         UpdateSavedScoresDisplay();
//     }

//     void Update()
//     {
//         if (shooter == null || goalArea == null) return;

//         // 更新得分显示
//         textScore.text = goalArea.score.ToString();

//         // 检测键盘 B 键输入触发 Store
//         if (Input.GetKeyDown(KeyCode.B))
//         {
//             PushedRestoreButton();
//         }

//         // 检测键盘 M 键输入触发 Reset
//         if (Input.GetKeyDown(KeyCode.M))
//         {
//             PushedResetButton();
//         }
//     }

//     public void PushedResetButton()
//     {
//         if (goalArea != null)
//         {
//             goalArea.ResetScore(); 
//         }
//         textScore.text = "0"; 
//     }

//     public void PushedRestoreButton()
//     {
//         // 开始延迟保存的协程
//         StartCoroutine(SaveScoreAfterDelay(10f));
//     }

//     private IEnumerator SaveScoreAfterDelay(float delay)
//     {
        
//         yield return new WaitForSeconds(delay);

        
//         string currentDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
//         int score = goalArea.score;
//         string rating = GetScoreRating(score); 

        
//         string scoreRecord = $"Retention date： {currentDate}        Score： {score}        Evaluation： {rating}";

        
//         if (!savedScores.Contains(scoreRecord))
//         {
//             savedScores.Add(scoreRecord);

            
//             UpdateSavedScoresDisplay();

            
//             string savedData = string.Join("|", savedScores); 
//             PlayerPrefs.SetString("SavedScores", savedData);
//             PlayerPrefs.Save();

//             Debug.Log($"Score saved after {delay} seconds: {scoreRecord}");
//         }
//     }

//     private string GetScoreRating(int score)
//     {
//         if (score < 5)
//         {
//             return "Normal";
//         }
//         else if (score <= 10)
//         {
//             return "Excellence";
//         }
//         else
//         {
//             return "Perfect";
//         }
//     }

//     private void UpdateSavedScoresDisplay()
//     {
//         if (savedScores.Count == 0)
//         {
//             textSavedScores.text = "No saved scores";
//         }
//         else
//         {
            
//             textSavedScores.text = string.Join("\n", savedScores);
//         }
//     }
// }

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class GUI : MonoBehaviour
{
    public Shooter shooter;
    public GoalArea goalArea;

    public Text textScore;
    public Text textSavedScores;

    private List<string> savedScores = new List<string>();

    private InputAction storeAction;
    private InputAction resetAction;

    void Start()
    {
        if (shooter == null)
        {
            shooter = FindObjectOfType<Shooter>();
        }
        if (goalArea == null)
        {
            goalArea = FindObjectOfType<GoalArea>();
        }
        if (textScore == null || textSavedScores == null)
        {
            Debug.LogError("UI components are not assigned in the Inspector!");
        }

        //清除保存的历史记录
        // if (PlayerPrefs.HasKey("SavedScores"))
        // {
        //     PlayerPrefs.DeleteKey("SavedScores");
        //     PlayerPrefs.Save();
        // }

        
        if (PlayerPrefs.HasKey("SavedScores"))
        {
            string savedData = PlayerPrefs.GetString("SavedScores");
            if (!string.IsNullOrEmpty(savedData))
            {
                savedScores = new List<string>(savedData.Split('|')); 
            }
        }

        
        UpdateSavedScoresDisplay();

        
        storeAction = new InputAction("Store", binding: "<XRController>{RightHand}/primaryButton");
        resetAction = new InputAction("Reset", binding: "<XRController>{RightHand}/secondaryButton");

        storeAction.Enable();
        resetAction.Enable();
    }

    void Update()
    {
        if (shooter == null || goalArea == null) return;

        
        textScore.text = goalArea.score.ToString();

        // 检测 Store 按钮（右手控制器的 primaryButton）
        if (storeAction.triggered)
        {
            PushedRestoreButton();
        }

        // 检测 Reset 按钮（右手控制器的 secondaryButton）
        if (resetAction.triggered)
        {
            PushedResetButton();
        }
    }

    public void PushedResetButton()
    {
        if (goalArea != null)
        {
            goalArea.ResetScore(); 
        }
        textScore.text = "0"; 
    }

    public void PushedRestoreButton()
    {
        // 开始延迟保存的协程
        StartCoroutine(SaveScoreAfterDelay(60f));
    }

    private IEnumerator SaveScoreAfterDelay(float delay)
    {
        // 等待指定时间
        yield return new WaitForSeconds(delay);

        // 获取当前日期和得分
        string currentDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        int score = goalArea.score;
        string rating = GetScoreRating(score); 

        // 构造记录内容
        string scoreRecord = $"Retention date： {currentDate}        Score： {score}        Evaluation： {rating}";

        // 避免重复保存
        if (!savedScores.Contains(scoreRecord))
        {
            savedScores.Add(scoreRecord);

            
            UpdateSavedScoresDisplay();

            
            string savedData = string.Join("|", savedScores); 
            PlayerPrefs.SetString("SavedScores", savedData);
            PlayerPrefs.Save();

            Debug.Log($"Score saved after {delay} seconds: {scoreRecord}");
        }
    }

    private string GetScoreRating(int score)
    {
        if (score < 5)
        {
            return "Normal";
        }
        else if (score <= 10)
        {
            return "Excellence";
        }
        else
        {
            return "Perfect";
        }
    }

    private void UpdateSavedScoresDisplay()
    {
        if (savedScores.Count == 0)
        {
            textSavedScores.text = "No History";
        }
        else
        {
            
            textSavedScores.text = string.Join("\n", savedScores);
        }
    }
}
