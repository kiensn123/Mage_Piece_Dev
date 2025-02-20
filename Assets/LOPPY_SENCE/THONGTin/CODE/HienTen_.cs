using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HienTen_ : MonoBehaviour
{

    [Header("UI")]
    public Text Display_Name;
    public Slider Thanh_Lv;
    public Text Lv;

    void Start()
    {
        Display_Name.text = Call_DuLieu_Player.Instance.player_Mage.Thong_Tin_Co_Ban.DisplayName;
        Lv.text =Call_DuLieu_Player.Instance.player_Mage.Thong_So.Capdo.ToString();
        Thanh_Lv.value = Call_DuLieu_Player.Instance.player_Mage.Thong_So.Diem_KinhNghiem/100;
    }

}
