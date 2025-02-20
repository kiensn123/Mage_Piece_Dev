using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hien_Tien : MonoBehaviour
{
    public Text Tien;
    public Text Ruby;


    void Start()
    {
        Tien.text  = Call_DuLieu_Player.Instance.player_Mage.Thong_So.Tien.ToString();
        Ruby.text = Call_DuLieu_Player.Instance.player_Mage.Thong_So.Ruby.ToString();
    }
}
