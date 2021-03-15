using PhamTrongTruong_5951071113.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PhamTrongTruong_5951071113.Controllers
{
    public class StudentController : ApiController
    {
        public Student Get()
        {
            return new Student
            {
                MaSV = "5951071113",
                Ten = "Phạm Trọng Trường",
                QueQuan = "Gia Lai",
                GioiTinh = "Nam",
                Lop = "Công Nghệ Thông Tin K59",
            };

        }
    }
}
