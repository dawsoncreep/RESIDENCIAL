using Common.CustomFilters;
using Model.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.Domain
{
    public class LocationUserNotification : AuditEntity,ISoftDeleted
    {
        [Key]
        public int Id { get; set; }
        public ICollection<Notification>    NotificationId { get; set; }
        //public ICollection<LocationUser> LocationUserId { get; set; }
        public bool Deleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
