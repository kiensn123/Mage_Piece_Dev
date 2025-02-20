using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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


    public async void  Load_Secne(){
        An.SetActive(false);
        Hien.SetActive(true);
        await Call_DuLieu_Player.Instance.CallDuLieu(); 
        Load_Sence_KoDongBo("Loopy_Sence");
    }




}
