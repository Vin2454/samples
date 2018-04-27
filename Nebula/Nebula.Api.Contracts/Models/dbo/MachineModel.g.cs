using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace NebulaNS.Api.Contracts
{
	public partial class MachineModel
	{
		public MachineModel()
		{}

		public MachineModel(
			string description,
			string jwtKey,
			string lastIpAddress,
			Guid machineGuid,
			string name)
		{
			this.Description = description.ToString();
			this.JwtKey = jwtKey.ToString();
			this.LastIpAddress = lastIpAddress.ToString();
			this.MachineGuid = machineGuid.ToGuid();
			this.Name = name.ToString();
		}

		private string description;

		[Required]
		public string Description
		{
			get
			{
				return this.description;
			}

			set
			{
				this.description = value;
			}
		}

		private string jwtKey;

		[Required]
		public string JwtKey
		{
			get
			{
				return this.jwtKey;
			}

			set
			{
				this.jwtKey = value;
			}
		}

		private string lastIpAddress;

		[Required]
		public string LastIpAddress
		{
			get
			{
				return this.lastIpAddress;
			}

			set
			{
				this.lastIpAddress = value;
			}
		}

		private Guid machineGuid;

		[Required]
		public Guid MachineGuid
		{
			get
			{
				return this.machineGuid;
			}

			set
			{
				this.machineGuid = value;
			}
		}

		private string name;

		[Required]
		public string Name
		{
			get
			{
				return this.name;
			}

			set
			{
				this.name = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>9c5f528cdaf6bf60db99e9eb1c6ca82e</Hash>
</Codenesium>*/