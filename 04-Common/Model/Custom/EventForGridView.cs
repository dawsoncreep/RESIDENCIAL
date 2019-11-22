using Model.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Custom
{
    public class EventForGridView
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name", ResourceType = typeof(Resources.Resources))]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Description", ResourceType = typeof(Resources.Resources))]
        [MaxLength(100)]
        public string Description { get; set; }

        [Display(Name = "DateStart", ResourceType = typeof(Resources.Resources))]
        [DataType(DataType.DateTime)]
        public DateTime DateStart { get; set; } = DateTime.Now;


        [Display(Name = "DateEnd", ResourceType = typeof(Resources.Resources))]
        [DataType(DataType.DateTime)]
        public DateTime DateEnd { get; set; } = DateTime.Now.AddDays(1);

        [Display(Name = "EventType", ResourceType = typeof(Resources.Resources))]
        public EventType EventType { get; set; }

        public String EventTypeId { get; set; }

        [Display(Name = "Location", ResourceType = typeof(Resources.Resources))]
        public Location Location { get; set; }

        public String LocationId { get; set; }

        [Display(Name = "External", ResourceType = typeof(Resources.Resources))]
        public External External { get; set; }

        public String ExternalId { get; set; }

        public List<Location> lstLocation { get; set; }

        public List<EventType> lstEventType { get; set; }

        public String lstJSONExternal { get; set; }




    }
}
