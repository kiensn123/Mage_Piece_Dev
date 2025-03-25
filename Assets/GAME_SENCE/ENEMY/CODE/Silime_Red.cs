using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Silime_Red : Ab_Enemy_1 , I_Enemy
{



    [Header("Move")]
    public float Huong;
    private bool IS_Move;   

    private Vector3 point_Den;

    public void DIE()
    {
        
    }

    public void MOVE()
    {
        
    }

    void Start()
    {
        KhoiTao_Start();
        StartCoroutine(KiemTra_TrenMatDat());
    }
    void Update()
    {
        if (!DieuKien()){return;}
        MOVE();
    }

    public bool DieuKien(){
        return true;
    }

    public bool Huong_Ben_Trai(){
        return point_Den.x>transform.position.x;
    }
}
