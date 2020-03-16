using System.Collections.Generic;

namespace CascadeExamples.Model
{
    internal class Invoice
    {
        public virtual int Id { get; set; }
        public virtual string Number { get; }
        public virtual IEnumerable<InvoiceRow> Rows { get; set; }

        protected Invoice() { }

        public Invoice(string number)
        {
            Rows = new List<InvoiceRow>();
            Number = number;
        }

        public virtual void AddRow(InvoiceRow row)
        {
            row.Invoice = this;
            ((IList<InvoiceRow>)Rows).Add(row);
        }
    }
}
