using CascadeExamples.Model;
using FluentNHibernate.Mapping;

namespace CascadeExamples.Mappings
{
    internal class InvoiceMap : ClassMap<Invoice>
    {
        public InvoiceMap()
        {
            Id(invoice => invoice.Id);
            Map(invoice => invoice.Number);
            HasMany(invoice => invoice.Rows)
                .KeyColumn("InvoiceId")
                // NHibernate will first persist the entity that 'owns' the collection (Invoice),
                // and will persist the entities that are in the collection afterwards,
                // avoiding an additional UPDATE statement.
                .Inverse()

                // NH3 and above allow to correct save entities in case of uni-directional one-to-many
                // mapping without annoying save null-save-update cycle, if you set both not-null="true"
                // on <key> and inverse="false" on <one-to-many>. With the following 3 options, no
                // References() is required on InvoiceRowMap.
                // .Not.Inverse()
                // .Not.KeyNullable()
                // .Not.KeyUpdate()

                .Cascade.SaveUpdate();
        }
    }
}
