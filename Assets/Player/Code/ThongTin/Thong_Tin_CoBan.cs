

using System.Collections.Generic;

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


    public int Tien { get; set; }

    public int Ruby { get; set; }

    public int Diem_Mau {get;set;}

    public int DiemMana {get;set;}

    public int Capdo {get;set;}

    public float Diem_KinhNghiem {get;set;}
}



public class TienTrinh{
    public List<int> Map_Win;
    public int Skill_Id { get; set; }

}