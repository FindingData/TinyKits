///////////////////////////////////////////////////////////
//  EntityBase.cs
//  Implementation of the Class EntityBase
//  Generated by Enterprise Architect
//  Created on:      29-9��-2018 11:13:53
//  Original author: drago
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



namespace FD.Tiny.FormBuilder {
	public class EntityBase {

        public EntityBase()
        {
            this.CREATED_TIME = DateTime.Now;
            this.IS_DELETED = 0;
        }

		public decimal CREATED_BY{
			get;
			set;
		}

		public DateTime CREATED_TIME{
			get;
			set;
		}

		public decimal? MODIFIED_BY{
			get;
			set;
		}

		public DateTime? MODIFIED_TIME{
			get;
			set;
		}

		public decimal IS_DELETED{
			get;
			set;
		}

	}//end EntityBase

}//end namespace Entities