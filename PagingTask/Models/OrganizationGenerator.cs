using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PagingTask.Models
{
    public static class OrganizationGenerator
    {
        private static Random random = new Random();

        public static string RandomOrganizationName(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }


        public static List<Organization> OrganizationList(int count)
        {
            List<Organization> innerList = new List<Organization>();

            for(int i=0; i<count; i++)
            {
                innerList.Add(new Organization(RandomOrganizationName(10)));
            }

            return innerList;
        }

    }
}
