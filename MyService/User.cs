using System;
using System.Collections.Generic;
using System.Text;

namespace MyService
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set;}
        public string UserPass { get; set; }
        public bool IsDeleted { get; set; }
    }
}
