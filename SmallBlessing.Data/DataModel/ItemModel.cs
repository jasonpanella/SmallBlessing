using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallBlessing.Data.DataModel
{
    public class ItemModel
    {
        public ItemModel()
        { }
        public int ItemID { get; set; }

        /// <summary>
        /// Gets or sets member id
        /// </summary>
        public string Description { get; set; }

        public string Comments { get; set; }

        public string Initials { get; set; }

        public DateTime Date { get; set; }
        
        /// <summary>
        /// Gets or sets member id
        /// </summary>
        public int PersonID { get; set; }

        
    }
}
