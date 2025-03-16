﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Exam_MVC_App.Models;

public partial class Stundent_Course
{
    [Key]
    public int Id { get; set; }

    public int Course_Id { get; set; }

    public int User_Id { get; set; }

    [ForeignKey("Course_Id")]
    [InverseProperty("Stundent_Courses")]
    public virtual Course Course { get; set; } = null!;

    [ForeignKey("User_Id")]
    [InverseProperty("Stundent_Courses")]
    public virtual User User { get; set; } = null!;
}