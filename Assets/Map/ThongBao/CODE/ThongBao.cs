using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThongBao : MonoBehaviour
{
    public Text ThongBaoText;

    public Button Thoat;

    private Animator ThongBao_Animator;

    void Start()
    {
      
        ThongBao_Animator = gameObject.GetComponent<Animator>();
        ThongBao_Animator.Play("MoThongBao");
        Thoat.onClick.AddListener(ThoatThongBao);
    }


    void ThoatThongBao(){
        StartCoroutine(ChayAni());
    }

    IEnumerator ChayAni(){
       ThongBao_Animator.Play("DongThongBao");
        // Lấy độ dài animation
         yield return null;  
        float animationLength = ThongBao_Animator.GetCurrentAnimatorStateInfo(0).length;
        // Đợi animation chạy hết
        yield return new WaitForSeconds(animationLength);
        // Xóa gameObject
        Destroy(gameObject);
    }
}
