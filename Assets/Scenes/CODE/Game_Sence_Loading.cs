using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Sence_Loading : Sence_Manager
{
    public Button Start_Game;

    void Start()
    {
        Start_Game.onClick.AddListener(ChuyenSenceCHoiGame);
    }

    public void ChuyenSenceCHoiGame(){
        Load_Sence_BinhThuong("GameSecne");
    }
}
