using System.ComponentModel.DataAnnotations;

namespace BaiThi_BNA
{
    public class BNA_Cau3
    {   
        [Key]
        [Display (Name ="Mã Sinh Viên")]
        public string MaSv { get; set; }
        [Display (Name ="Họ Tên")]
        public string HoTen { get; set; }
        [Display (Name ="Số Điện Thoại")]
        public string SDT { get; set; }
    }
}