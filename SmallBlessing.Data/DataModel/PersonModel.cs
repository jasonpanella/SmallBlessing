using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmallBlessing.Data.DataModel;

namespace SmallBlessing.Data.DataModel
{
    public class PersonModel
    {
        public PersonModel()
        { }

        /// <summary>
        /// Gets or sets member id
        /// </summary>
        public int PersonID { get; set; }

        /// <summary>
        /// Gets or sets member id
        /// </summary>
        public string FirstName { get; set; }
        
        /// <summary>
        /// Gets or sets member id
        /// </summary>
        public string MiddleIntial { get; set; }

        /// <summary>
        /// Gets or sets member id
        /// </summary>
        public string LastName { get; set; }
        
        /// <summary>
        /// Gets or sets member id
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets member id
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets member id
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets member id
        /// </summary>
        public string Zip { get; set; }

        /// <summary>
        /// Gets or sets member id
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets member id
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets member id
        /// </summary>
        public bool LeaveMessage { get; set; }

        /// <summary>
        /// Gets or sets member id
        /// </summary>
        public string ChurchName { get; set; }

        /// <summary>
        /// Gets or sets member id
        /// </summary>
        public bool ChurchHome { get; set; }

        /// <summary>
        /// Gets or sets member id
        /// </summary>
        public string Opinion { get; set; }
        /// <summary>
        /// Gets or sets member id
        /// </summary>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// Gets or sets member id
        /// </summary>
        public DateTime DateUpdated { get; set; }

        public int ExportFlag { get; set; }

        public List<DependentModel> DependentModelList { get; set; }

        public List<ItemModel> ItemModelList { get; set; }
    }
}
