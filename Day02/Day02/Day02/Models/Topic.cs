using System;
using System.Collections.Generic;

namespace Day02.Models;

public partial class Topic
{
    public int Top_Id { get; set; }

    public string? Top_Name { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
