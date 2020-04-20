using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginInMVC4WithEF.Entity
{
    public class State
    {
        public string SelectedItem { get; set; }
        public List<SelectListItem> SDL { get; set; }
    }
}