using CascadeExamples.Model;
using FluentNHibernate.Mapping;

namespace CascadeExamples.Mappings
{
    internal class InvoiceRowMap : ClassMap<InvoiceRow>
    {
        public InvoiceRowMap()
        {
            Id(row => row.Id);
            Map(row => row.Content);

            // With this configuration, we create the bi-directional
            // relation, so we need to set the "Invoice" property
            // every time before saving a "Invoice" entity (because of not null setting).
            References(row => row.Invoice)
                .Column("InvoiceId")
                .Not.Nullable();
        }
    }
}
