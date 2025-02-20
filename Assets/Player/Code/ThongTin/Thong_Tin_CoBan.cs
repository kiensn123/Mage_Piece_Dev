

using System;
using System.Collections.Generic;




[Serializable]
public class Player_Mage{

    
    public Thong_Tin_CoBan Thong_Tin_Co_Ban;
    public Thongso Thong_So;

    public TienTrinh Tien_Trinh;

  
    public Player_Mage()
    {
    }

 
}





public class Thong_Tin_CoBan 
{
    public string DisplayName { get; set; }
    public string Email { get; set; }
    public Thong_Tin_CoBan(string displayName, string email)
    {
        DisplayName = displayName;
        Email = email;
    }
}

public class Thongso{


    public int Tien ;

    public int Ruby ;

    public int Diem_Mau ;

    public int DiemMana ;

    public int Capdo ;

    public float Diem_KinhNghiem ;


    public Thongso(int tien, int ruby, int diemMau, int diemMana, int capdo, int diemKinhNghiem) {
        this.Tien = tien;
        this.Ruby = ruby;
        this.Diem_Mau = diemMau;
        this.DiemMana = diemMana;
        this.Capdo = capdo;
        this.Diem_KinhNghiem = diemKinhNghiem;
    }
}

public class TienTrinh{
    public List<int> Map_Win;
    public int Skill_Id { get; set; }

    public TienTrinh(List<int> Map_Win, int Skill_Id){
        this.Map_Win =Map_Win;
        this.Skill_Id = Skill_Id;
    }

}