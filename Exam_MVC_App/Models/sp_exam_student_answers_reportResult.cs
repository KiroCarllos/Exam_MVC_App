﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable

namespace Exam_MVC_App.Models
{
    public partial class sp_exam_student_answers_reportResult
    {
        public int Question_Id { get; set; }
        [StringLength(2147483647)]
        public string Question { get; set; } = default!;
        [StringLength(2147483647)]
        public string Right_Answer { get; set; } = default!;
        [StringLength(2147483647)]
        public string Student_Answer { get; set; } = default!;
    }
}
