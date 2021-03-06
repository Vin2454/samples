using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("DatabaseLog", Schema="dbo")]
	public partial class DatabaseLog : AbstractEntity
	{
		public DatabaseLog()
		{
		}

		public virtual void SetProperties(
			int databaseLogID,
			string databaseUser,
			string @event,
			string @object,
			DateTime postTime,
			string schema,
			string tsql,
			string xmlEvent)
		{
			this.DatabaseLogID = databaseLogID;
			this.DatabaseUser = databaseUser;
			this.@Event = @event;
			this.@Object = @object;
			this.PostTime = postTime;
			this.Schema = schema;
			this.Tsql = tsql;
			this.XmlEvent = xmlEvent;
		}

		[Key]
		[Column("DatabaseLogID")]
		public int DatabaseLogID { get; private set; }

		[MaxLength(128)]
		[Column("DatabaseUser")]
		public string DatabaseUser { get; private set; }

		[MaxLength(128)]
		[Column("Event")]
		public string @Event { get; private set; }

		[MaxLength(128)]
		[Column("Object")]
		public string @Object { get; private set; }

		[Column("PostTime")]
		public DateTime PostTime { get; private set; }

		[MaxLength(128)]
		[Column("Schema")]
		public string Schema { get; private set; }

		[Column("TSQL")]
		public string Tsql { get; private set; }

		[Column("XmlEvent")]
		public string XmlEvent { get; private set; }
	}
}

/*<Codenesium>
    <Hash>e08b5416f88ad1531e4057b250437b4c</Hash>
</Codenesium>*/