using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HienTen_ : MonoBehaviour
{
    public Text Display_Name;

    void Start()
    {
        Display_Name.text = Call_DuLieu_Player.Instance.Call_ThonTing_NguoiChoi().DisplayName;
    }

}
