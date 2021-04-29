using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] CategoryImage { get; set; }
        public string ContentType { get; set; }
        public ICollection<Contact> Contact { get; set; } = new HashSet<Contact>();
    }
}
