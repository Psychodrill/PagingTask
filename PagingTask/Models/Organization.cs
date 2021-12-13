using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PagingTask.Models
{
    public class Organization
    {

        public Organization(string name)
        {
            this.Name = name;
        }

        [DisplayName ("Имя организации")]
        public string Name  { get; set; }
    }
}
