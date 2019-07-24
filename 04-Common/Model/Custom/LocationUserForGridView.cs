using Model.Auth;
using Model.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Custom
{
    public class LocationUserForGridView
    {
        [Display(Name = "Id", ResourceType = typeof(Resources.Resources))]
        public int Id { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public Location Location { get; set; }

        public IEnumerable<UserForGridView> lstAplicationUser { get; set; }
        public IEnumerable<Location> lstLocation { get; set; }
    }
}
