using System;
using System.Collections.Generic;

namespace Labb3Högstadieskolan.Models;

public partial class Subject
{
    public int Subjectid { get; set; }

    public string Subjects { get; set; } = null!;

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
