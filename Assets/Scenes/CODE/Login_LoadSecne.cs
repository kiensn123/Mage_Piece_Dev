using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login_LoadSecne : Sence_Manager
{
    public Button Start_Game;
    public GameObject An;
    public GameObject Hien;

    void Start()
    {
        Start_Game.onClick.AddListener(Load_Secne);
    }


    void Load_Secne(){
        An.SetActive(false);
        Hien.SetActive(true);
        Load_Sence_KoDongBo("Loopy_Sence");
    }


}
