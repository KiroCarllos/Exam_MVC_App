﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable

namespace Exam_MVC_App.Models
{
    public partial class sp_SelectRightAnswersResult
    {
        public int RightAnswerId { get; set; }
        [StringLength(2147483647)]
        public string Right_Answer { get; set; } = default!;
        public int QuestionId { get; set; }
        [StringLength(2147483647)]
        public string QuestionName { get; set; } = default!;
        [StringLength(30)]
        public string Type { get; set; } = default!;
        [StringLength(10)]
        public string Type_Difficult { get; set; } = default!;
        public byte Mark { get; set; }
    }
}
