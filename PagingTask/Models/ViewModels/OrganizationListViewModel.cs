using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PagingTask.Models.ViewModels
{
    public class OrganizationListViewModel
    {

        public IEnumerable<Organization> Organizations { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
