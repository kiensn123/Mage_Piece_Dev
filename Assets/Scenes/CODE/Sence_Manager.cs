using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public abstract class Sence_Manager : MonoBehaviour
{



    [Header("Abtrac")]
    public string Sence_Name;

    public Slider slider;

    public void Load_Sence_KoDongBo(string Sence_Name_1){
        StartCoroutine(IEnumerator_Load_Sence_KoDongBo(Sence_Name_1));
    }

    IEnumerator IEnumerator_Load_Sence_KoDongBo(string Sence_Name_1){
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(Sence_Name_1);
        asyncOperation.allowSceneActivation = false;

        while (!asyncOperation.isDone)
        {

            // Cập nhật giá trị slider từ 0 đến 1
            slider.value = asyncOperation.progress;

            if (asyncOperation.progress >= 0.9f)
            {
                 slider.value = 1f; // Đảm bảo slider đầy khi gần xong
                // Khi scene gần load xong, cho phép kích hoạt
                asyncOperation.allowSceneActivation = true;
            }

            yield return null;
        }


        yield return null;
    }

    public void Load_Sence_BinhThuong(string Sence_Name_1){
        SceneManager.LoadScene(Sence_Name_1);
    }
}
