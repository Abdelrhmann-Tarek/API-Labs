using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Day1.Models;

[Table("Course")]
public partial class Course
{
    [Key]
    public int Id { get; set; }

    [Column("Crs_name")]
    [StringLength(50)]
    public string? CrsName { get; set; }

    [Column("crs_desc")]
    [StringLength(100)]
    public string? CrsDesc { get; set; }

    public int? Duration { get; set; }
}
