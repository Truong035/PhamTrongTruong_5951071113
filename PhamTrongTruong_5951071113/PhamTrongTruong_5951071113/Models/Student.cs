using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PhamTrongTruong_5951071113.Models
{
    [DataContract]
    public class Student
    {
        [DataMember(Name ="masv")]
        public string MaSV { get; set; }
        [DataMember(Name = "ten")]
        public string Ten{ get; set; }
        [DataMember(Name = "gioitinh")]
        public string GioiTinh{ get; set; }
        [DataMember(Name = "lop")]
        public string Lop{ get; set; }
        [DataMember(Name = "quequan")]
        public string QueQuan{ get; set; }
    }
}