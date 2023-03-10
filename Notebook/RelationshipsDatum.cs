using System;
using System.Collections.Generic;

namespace Notebook;

public partial class RelationshipsDatum
{
    public long RdId { get; set; }

    public long? FioId { get; set; }

    public string? Role { get; set; }

    public string? Description { get; set; }

    public virtual Fiodatum? Fio { get; set; }
}
