using System.Configuration;
using CascadeExamples.Model;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace CascadeExamples
{
    internal class Program
    {
        private readonly ISessionFactory _sessionFactory;

        public Program()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["playground-nhibernate"].ConnectionString;

            _sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString).ShowSql())
                .Mappings(map => map.FluentMappings.AddFromAssemblyOf<Program>())
                // It will not create the database, but will create tables based on the mapping configurations.
                // This configuration will also drop all existing tables!
                .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, true))
                .BuildSessionFactory();
        }

        public void Run()
        {
            using (ISession session = _sessionFactory.OpenSession())
            {
                var invoice = new Invoice("2019/01/01");
                invoice.AddRow(new InvoiceRow("Order no 7"));
                session.Save(invoice);
            }
        }

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run();
        }
    }
}
