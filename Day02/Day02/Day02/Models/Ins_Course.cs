using System;
using System.Collections.Generic;

namespace Day02.Models;

public partial class Ins_Course
{
    public int Ins_Id { get; set; }

    public int Crs_Id { get; set; }

    public string? Evaluation { get; set; }

    public virtual Course Crs { get; set; } = null!;

    public virtual Instructor Ins { get; set; } = null!;
}
