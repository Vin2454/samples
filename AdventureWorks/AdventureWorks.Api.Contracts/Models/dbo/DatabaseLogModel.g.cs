using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class DatabaseLogModel
	{
		public DatabaseLogModel()
		{}

		public DatabaseLogModel(DateTime postTime,
		                        string databaseUser,
		                        string @event,
		                        string schema,
		                        string @object,
		                        string tSQL,
		                        string xmlEvent)
		{
			this.PostTime = postTime.ToDateTime();
			this.DatabaseUser = databaseUser;
			this.@Event = @event;
			this.Schema = schema;
			this.@Object = @object;
			this.TSQL = tSQL;
			this.XmlEvent = xmlEvent;
		}

		public DatabaseLogModel(POCODatabaseLog poco)
		{
			this.PostTime = poco.PostTime.ToDateTime();
			this.DatabaseUser = poco.DatabaseUser;
			this.@Event = poco.@Event;
			this.Schema = poco.Schema;
			this.@Object = poco.@Object;
			this.TSQL = poco.TSQL;
			this.XmlEvent = poco.XmlEvent;
		}

		private DateTime _postTime;
		[Required]
		public DateTime PostTime
		{
			get
			{
				return _postTime;
			}
			set
			{
				this._postTime = value;
			}
		}

		private string _databaseUser;
		[Required]
		public string DatabaseUser
		{
			get
			{
				return _databaseUser;
			}
			set
			{
				this._databaseUser = value;
			}
		}

		private string @event;
		[Required]
		public string @Event
		{
			get
			{
				return @event;
			}
			set
			{
				this.@event = value;
			}
		}

		private string _schema;
		public string Schema
		{
			get
			{
				return _schema.IsEmptyOrZeroOrNull() ? null : _schema;
			}
			set
			{
				this._schema = value;
			}
		}

		private string @object;
		public string @Object
		{
			get
			{
				return @object.IsEmptyOrZeroOrNull() ? null : @object;
			}
			set
			{
				this.@object = value;
			}
		}

		private string _tSQL;
		[Required]
		public string TSQL
		{
			get
			{
				return _tSQL;
			}
			set
			{
				this._tSQL = value;
			}
		}

		private string _xmlEvent;
		[Required]
		public string XmlEvent
		{
			get
			{
				return _xmlEvent;
			}
			set
			{
				this._xmlEvent = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>13db14a6e2d0c8caefa4b1549b40e91b</Hash>
</Codenesium>*/