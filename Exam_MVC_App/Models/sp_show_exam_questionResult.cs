﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable

namespace Exam_MVC_App.Models
{
    public partial class sp_show_exam_questionResult
    {
        public int Id { get; set; }
        public int Question_Id { get; set; }
        public int Exam_Id { get; set; }
    }
}
