using proj.Models.Entities;
using proj.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proj.ViewModels
{
    public class MenuViewModel : PropertyChangedBase
    {
        public bool IsAdmin => Session.HasRole("Administrator");
    }

}
