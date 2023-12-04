using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace Sweeter.Server.Persistence;

public class ContactDatabase : ContactRepository
{
	private readonly IConfiguration configuration;

	public ContactDatabase(IConfiguration configuration)
	{
		this.configuration = configuration;
	}
	public Task Delete(Contact entity)
	{
		throw new NotImplementedException();
	}

	public async Task<IEnumerable<Contact>> GetAll()
	{
		using IDbConnection connection = new NpgsqlConnection(configuration.GetConnectionString("CRM"));
		return await connection.QueryAsync<Contact>("select id as Id, first_name as FirstName, last_name as LastName, email as Email, phone_number as PhoneNumber, created_on as CreatedOn, created_by as CreatedBy, updated_on as UpdatedOn, updated_by as UpdatedBy from public.contact");
	}

	public async Task Insert(Contact entity)
	{
		DynamicParameters parameters = new DynamicParameters();
		parameters.Add("firstname", entity.FirstName);
		parameters.Add("lastname", entity.LastName);
		parameters.Add("email", entity.Email);
		parameters.Add("phonenumber", entity.PhoneNumber);
		parameters.Add("createdon", entity.CreatedOn);
		parameters.Add("createdby", entity.CreatedBy);

		using IDbConnection connection = new NpgsqlConnection(configuration.GetConnectionString("CRM"));
		await connection.ExecuteAsync("contact_insert", parameters, commandType: CommandType.StoredProcedure);
	}

	public Task Update(Contact entity)
	{
		throw new NotImplementedException();
	}
}
