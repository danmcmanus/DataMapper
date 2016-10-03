using DataMappingSample.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMappingSample
{
    public class ExtendedUserItem
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string ModelNumber { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public int? UserCategoryId { get; set; }

        public int? UserTradeId { get; set; }

        public int? UserPersonId { get; set; }

        public int UserManufacturerId { get; set; }

        public int? UserLocationId { get; set; }

        public string SerialNumber { get; set; }
        public string ToolNumber { get; set; }
        public string PurchaseLocation { get; set; }

        public string OrderInformationImageUrl { get; set; }
        public string ItemizationImageUrl { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public decimal? Price { get; set; }
        public DateTime? PurchasedOn { get; set; }
        //public ItemStatus Status { get; set; }

        public DateTime? LastSeen { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }

        public bool IsDeleted { get; set; }
        public bool IsMissing { get; set; }


        /// <summary>
        /// The Product Id from the Item table, based on the UserItem's model number.
        /// </summary>
        public int? ProductId { get; set; }

        /// <summary>
        /// The IsBluetoothCapable flag from the Item table, based on the UserItem's model number.
        /// </summary>
        public bool? IsBluetoothCapable { get; set; }

        /// <summary>
        /// The SerialNumber Id from the SerialNumber table, based on the UserItem's string-based SerialNumber.
        /// </summary>
        public int? SerialNumberId { get; set; }
        public int? ItemInstanceId { get; set; }

        [ForeignKey("UserCategoryId")]
        public UserCategory UserCategory { get; set; }

        [ForeignKey("UserTradeId")]
        public UserTrade UserTrade { get; set; }

        [ForeignKey("UserPersonId")]
        public UserPerson UserPerson { get; set; }

        [ForeignKey("UserManufacturerId")]
        public UserManufacturer UserManufacturer { get; set; }

        [ForeignKey("UserLocationId")]
        public UserLocation UserLocation { get; set; }
    }
}

