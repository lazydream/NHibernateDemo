using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPINhibernate.Models;

namespace WebAPINhibernate.Mappers
{
    public class StudentMap : ClassMapping<Student>
    {
        public StudentMap()
        {
            Id(x => x.ID, m => m.Generator(Generators.Native, g => g.Params(new { sequence = "autoinc_pk" })));
            Property(s => s.LastName);
            Property(s => s.FirstName);
        }
    }
}
