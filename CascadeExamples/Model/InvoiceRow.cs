namespace CascadeExamples.Model
{
    internal class InvoiceRow
    {
        public virtual int Id { get; set; }
        public virtual string Content { get; }
        public virtual Invoice Invoice { get; set; }

        protected InvoiceRow() { }

        public InvoiceRow(string content)
        {
            Content = content;
        }
    }
}
