using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoCenter
{
    class DBContext
    {
        private static PhotocenterEntities _context;
        public static PhotocenterEntities GetContext()
        {
            CreateContext();
            return _context;
        }
        private static void CreateContext()
        {
            if (_context == null)
                _context = new PhotocenterEntities();
        }
        public static void SaveChanges()
        {
            CreateContext();
            _context.SaveChanges();
            _context.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
        }
    }
}
