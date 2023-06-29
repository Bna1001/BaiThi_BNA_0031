using System.ComponentModel.DataAnnotations;

namespace BaiThi_BNA
{
    public class BNA_Cau3KeThua
    {   
        [Key]
        [Display (Name ="Mã Sinh Viên")]
        public string MaSv { get; set; }
        [Display (Name ="Họ Tên")]
        public string HoTen { get; set; }
        [Display (Name ="Số Điện Thoại")]
        public string SDT { get; set; }
        [Display (Name ="Địa Chỉ")]
        public string DiaChi { get; set; }
        [Display (Name ="Lớp Học")]
        public string LopHoc { get; set; }    
    }
}