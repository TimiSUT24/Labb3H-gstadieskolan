using System;
using System.Collections.Generic;

namespace Labb3Högstadieskolan.Models;

public partial class Position
{
    public int? Id { get; set; }

    public string? Position1 { get; set; }

    public virtual Personal? IdNavigation { get; set; }
}
