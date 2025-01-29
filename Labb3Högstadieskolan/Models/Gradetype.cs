using System;
using System.Collections.Generic;

namespace Labb3Högstadieskolan.Models;

public partial class Gradetype
{
    public int Id { get; set; }

    public string? Grade { get; set; }

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
