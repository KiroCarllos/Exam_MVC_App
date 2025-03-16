﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Exam_MVC_App.Models;

[Table("Question_Right_Answer")]
public partial class Question_Right_Answer
{
    [Key]
    public int Id { get; set; }

    [Unicode(false)]
    public string Right_Answer { get; set; } = null!;

    public int Question_Id { get; set; }

    [ForeignKey("Question_Id")]
    [InverseProperty("Question_Right_Answers")]
    public virtual Question Question { get; set; } = null!;
}