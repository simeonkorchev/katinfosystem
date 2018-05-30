using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure; // namespace for the EdmxWriter class
using System.Xml;

namespace Persistence
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var ctx = new KatSystemDbContext())
            {
                using (var writer = new XmlTextWriter(@"c:\Model.edmx", Encoding.Default))
                {
                    EdmxWriter.WriteEdmx(ctx, writer);
                }
            }
        }
    }
}
