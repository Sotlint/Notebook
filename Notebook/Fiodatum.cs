using System;
using System.Collections.Generic;

namespace Notebook;

public partial class Fiodatum
{
    public long FioId { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Patronomic { get; set; }

    public string? Gender { get; set; }

    public virtual ICollection<AddressDatum> AddressData { get; } = new List<AddressDatum>();

    public virtual ICollection<BirthdayDatum> BirthdayData { get; } = new List<BirthdayDatum>();

    public virtual ICollection<Congratulation> Congratulations { get; } = new List<Congratulation>();

    public virtual ICollection<ContactDatum> ContactData { get; } = new List<ContactDatum>();

    public virtual ICollection<RelationshipsDatum> RelationshipsData { get; } = new List<RelationshipsDatum>();
}
