using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission9_hls68.Models
{
    public interface IBookstoreRepository
    {
        IQueryable<Books> Books { get; }
    }
}
