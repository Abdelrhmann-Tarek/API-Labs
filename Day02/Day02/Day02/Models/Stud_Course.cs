using System;
using System.Collections.Generic;

namespace Day02.Models;

public partial class Stud_Course
{
    public int Crs_Id { get; set; }

    public int St_Id { get; set; }

    public int? Grade { get; set; }

    public virtual Course Crs { get; set; } = null!;

    public virtual Student St { get; set; } = null!;
}
