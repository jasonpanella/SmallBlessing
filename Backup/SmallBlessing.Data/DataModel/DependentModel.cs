using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmallBlessing.Data.DataModel
{
    public class DependentModel
    {
        public DependentModel()
        { }

        public int DependentID { get; set; }

        /// <summary>
        /// Gets or sets member id
        /// </summary>
        public string NameOfChild { get; set; }

        /// <summary>
        /// Gets or sets member id
        /// </summary>
        public DateTime BirthDate { get; set; }
        
        /// <summary>
        /// Gets or sets member id
        /// </summary>
        public string Relationship { get; set; }

        /// <summary>
        /// Gets or sets member id
        /// </summary>
        public string ChildLivesWith { get; set; }
        
        /// <summary>
        /// Gets or sets member id
        /// </summary>
        public int PersonID { get; set; }

        
    }
}
