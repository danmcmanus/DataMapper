using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DataMappingSample.Models;

namespace DataMappingSample
{
    public class UserItem
    {
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public Guid UserId { get; set; }

        [StringLength(32)]
        public string ModelNumber { get; set; }

        [StringLength(256)]
        public string Description { get; set; }

        [StringLength(256)]
        public string ImageUrl { get; set; }

        public int? UserCategoryId { get; set; }

        [ForeignKey("UserCategoryId")]
        public UserCategory UserCategory { get; set; }

        public int? UserTradeId { get; set; }

        [ForeignKey("UserTradeId")]
        public UserTrade UserTrade { get; set; }

        public int? UserPersonId { get; set; }

        [ForeignKey("UserPersonId")]
        public UserPerson UserPerson { get; set; }

        public int UserManufacturerId { get; set; }

        [ForeignKey("UserManufacturerId")]
        public UserManufacturer UserManufacturer { get; set; }

        public int? UserLocationId { get; set; }

        [ForeignKey("UserLocationId")]
        public UserLocation UserLocation { get; set; }

        [StringLength(64)]
        public string SerialNumber { get; set; }

        [StringLength(20)]
        public string ToolNumber { get; set; }

        //[StringLength(256)]
        //public string Notes { get; set; }  // This is only used for the excel import feature.

        [StringLength(64)]
        public string PurchaseLocation { get; set; }

        [StringLength(256)]
        public string OrderInformationImageUrl { get; set; }

        [StringLength(256)]
        public string ItemizationImageUrl { get; set; }

        public DateTime? PurchasedOn { get; set; }

        public decimal? Price { get; set; }

        public ItemStatus Status { get; set; }

        public int? ItemInstanceId { get; set; }

        [ForeignKey("ItemInstanceId")]
        public ItemInstance ItemInstance { get; set; }

        public DateTime? LastSeen { get; set; }

        public double? Longitude { get; set; }

        public double? Latitude { get; set; }

        public Guid? LastSeenBy { get; set; }

        public bool IsMissing { get; set; }

        public DateTime? MissingDate { get; set; }

        public int NotificationCount { get; set; }

        public DateTime? LastNotifiedDate { get; set; }

        public int EmailCount { get; set; }

        public int WebNotificationCount { get; set; }


        #region IAudit

        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public Guid ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }

        #endregion IAudit

        #region ISoftDelete
        public bool IsDeleted { get; set; }

        #endregion ISoftDelete
    }
}
