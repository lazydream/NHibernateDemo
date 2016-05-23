using NHibernate.Cfg;
using NHibernate;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using WebAPINhibernate.Models;

namespace WebAPINhibernate.Controllers
{
    public class HomeController : ApiController
    {
        public string GetSomething()
        {

            Configuration config = new Configuration();
            try
            {
                config.Configure();
            } catch (Exception e)
            {
                return e.InnerException.Message;
            }
            
            //    .DataBaseIntegration(db =>
            //    {
            //        db.ConnectionString = "server=127.0.0.1;port = 5432;database = Nhibernatepg;user id = postgres;password = zaragosa;";
            //        db.Dialect<PostgreSQLDialect>();
            //        db.LogFormattedSql = true;
            //        db.LogSqlInConsole = true;
            //    });

            //NHibernate.Tool.hbm2ddl.SchemaUpdate SchemaUpdater = new NHibernate.Tool.hbm2ddl.SchemaUpdate(config);
            

            ////Add the mapping
            var mapper = new ModelMapper();
            mapper.AddMappings(Assembly.GetExecutingAssembly().GetExportedTypes());

            HbmMapping mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
            config.AddMapping(mapping);


            var sefact = config.BuildSessionFactory();

            using (var session = sefact.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    var student1 = new Student();
                    student1.FirstName = "Kazimir";
                    student1.LastName = "Kovalenko";
                    session.Save(student1);
                    try
                    {
                        tx.Commit();
                    } catch (Exception e)
                    {
                        return e.InnerException.Message;
                    }

                }
            }
            return "Great";
        }
    }
}
