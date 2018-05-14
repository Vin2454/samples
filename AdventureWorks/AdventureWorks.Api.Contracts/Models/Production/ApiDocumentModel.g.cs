using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiDocumentModel
	{
		public ApiDocumentModel()
		{}

		public ApiDocumentModel(
			int changeNumber,
			byte[] document1,
			Nullable<short> documentLevel,
			string documentSummary,
			string fileExtension,
			string fileName,
			bool folderFlag,
			DateTime modifiedDate,
			int owner,
			string revision,
			Guid rowguid,
			int status,
			string title)
		{
			this.ChangeNumber = changeNumber.ToInt();
			this.Document1 = document1;
			this.DocumentLevel = documentLevel;
			this.DocumentSummary = documentSummary.ToString();
			this.FileExtension = fileExtension.ToString();
			this.FileName = fileName.ToString();
			this.FolderFlag = folderFlag.ToBoolean();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Owner = owner.ToInt();
			this.Revision = revision.ToString();
			this.Rowguid = rowguid.ToGuid();
			this.Status = status.ToInt();
			this.Title = title.ToString();
		}

		private int changeNumber;

		[Required]
		public int ChangeNumber
		{
			get
			{
				return this.changeNumber;
			}

			set
			{
				this.changeNumber = value;
			}
		}

		private byte[] document1;

		public byte[] Document1
		{
			get
			{
				return this.document1.IsEmptyOrZeroOrNull() ? null : this.document1;
			}

			set
			{
				this.document1 = value;
			}
		}

		private Nullable<short> documentLevel;

		public Nullable<short> DocumentLevel
		{
			get
			{
				return this.documentLevel.IsEmptyOrZeroOrNull() ? null : this.documentLevel;
			}

			set
			{
				this.documentLevel = value;
			}
		}

		private string documentSummary;

		public string DocumentSummary
		{
			get
			{
				return this.documentSummary.IsEmptyOrZeroOrNull() ? null : this.documentSummary;
			}

			set
			{
				this.documentSummary = value;
			}
		}

		private string fileExtension;

		[Required]
		public string FileExtension
		{
			get
			{
				return this.fileExtension;
			}

			set
			{
				this.fileExtension = value;
			}
		}

		private string fileName;

		[Required]
		public string FileName
		{
			get
			{
				return this.fileName;
			}

			set
			{
				this.fileName = value;
			}
		}

		private bool folderFlag;

		[Required]
		public bool FolderFlag
		{
			get
			{
				return this.folderFlag;
			}

			set
			{
				this.folderFlag = value;
			}
		}

		private DateTime modifiedDate;

		[Required]
		public DateTime ModifiedDate
		{
			get
			{
				return this.modifiedDate;
			}

			set
			{
				this.modifiedDate = value;
			}
		}

		private int owner;

		[Required]
		public int Owner
		{
			get
			{
				return this.owner;
			}

			set
			{
				this.owner = value;
			}
		}

		private string revision;

		[Required]
		public string Revision
		{
			get
			{
				return this.revision;
			}

			set
			{
				this.revision = value;
			}
		}

		private Guid rowguid;

		[Required]
		public Guid Rowguid
		{
			get
			{
				return this.rowguid;
			}

			set
			{
				this.rowguid = value;
			}
		}

		private int status;

		[Required]
		public int Status
		{
			get
			{
				return this.status;
			}

			set
			{
				this.status = value;
			}
		}

		private string title;

		[Required]
		public string Title
		{
			get
			{
				return this.title;
			}

			set
			{
				this.title = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>6ef3476eec877ddc3720f0dc40d2855a</Hash>
</Codenesium>*/