using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Data.Entity.Spatial;
namespace NebulaNS.Api.Contracts
{
	public partial class LinkLogModel
	{
		public LinkLogModel()
		{}

		public LinkLogModel(DateTime dateEntered,
		                    int id,
		                    int linkId,
		                    string log)
		{
			this.DateEntered = dateEntered.ToDateTime();
			this.Id = id.ToInt();
			this.LinkId = linkId.ToInt();
			this.Log = log;
		}

		public LinkLogModel(POCOLinkLog poco)
		{
			this.DateEntered = poco.DateEntered.ToDateTime();
			this.Id = poco.Id.ToInt();
			this.Log = poco.Log;

			LinkId = poco.LinkId.Value.ToInt();
		}

		private DateTime _dateEntered;
		public DateTime DateEntered
		{
			get
			{
				return _dateEntered;
			}
			set
			{
				this._dateEntered = value;
			}
		}

		private int _id;
		public int Id
		{
			get
			{
				return _id;
			}
			set
			{
				this._id = value;
			}
		}

		private int _linkId;
		public int LinkId
		{
			get
			{
				return _linkId;
			}
			set
			{
				this._linkId = value;
			}
		}

		private string _log;
		public string Log
		{
			get
			{
				return _log;
			}
			set
			{
				this._log = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>124891da3b0f6af55625de3e257c5919</Hash>
</Codenesium>*/