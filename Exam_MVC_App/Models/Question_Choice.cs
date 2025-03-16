﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Exam_MVC_App.Models;

public partial class Question_Choice
{
    [Key]
    public int Id { get; set; }

    [Unicode(false)]
    public string Choice { get; set; } = null!;

    [StringLength(10)]
    [Unicode(false)]
    public string? Choice_Type { get; set; }

    public int Question_Id { get; set; }

    [ForeignKey("Question_Id")]
    [InverseProperty("Question_Choices")]
    public virtual Question Question { get; set; } = null!;
}