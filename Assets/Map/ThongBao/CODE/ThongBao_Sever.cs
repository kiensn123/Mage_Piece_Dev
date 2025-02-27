using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThongBao_Sever : Singleton<ThongBao_Sever>
{

    public GameObject ThongBaoCoBan_Prefab;

    public GameObject UI_Cavana;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ThongBaoCoBan(string Text){
        GameObject thongBao = Instantiate(ThongBaoCoBan_Prefab,UI_Cavana.transform);
        ThongBao thongBao1 = thongBao.GetComponent<ThongBao>();
        thongBao1.ThongBaoText.text = Text;
    }
}
