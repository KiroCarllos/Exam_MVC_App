﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Exam_MVC_App.Models;

[Table("Track")]
public partial class Track
{
    [Key]
    public byte Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Name { get; set; }

    public int? Hours { get; set; }

    public int Mng_Id { get; set; }

    [InverseProperty("Track")]
    public virtual ICollection<Instructor_Detial> Instructor_Detials { get; set; } = new List<Instructor_Detial>();

    [ForeignKey("Mng_Id")]
    [InverseProperty("Tracks")]
    public virtual User Mng { get; set; } = null!;

    [InverseProperty("Track")]
    public virtual ICollection<Student_Detial> Student_Detials { get; set; } = new List<Student_Detial>();
}