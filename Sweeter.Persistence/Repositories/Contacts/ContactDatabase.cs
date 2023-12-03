using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Sweeter.Server.Persistence;

public class ContactDatabase : ContactRepository
{
	private readonly IConfiguration configuration;

	private readonly NpgsqlConnection connection;

	public ContactDatabase(IConfiguration configuration)
	{
		this.configuration = configuration;
		this.connection = new NpgsqlConnection(configuration.GetConnectionString("CRM"));
	}
	public Task Delete(Contact entity)
	{
		throw new NotImplementedException();
	}

	public async Task<IEnumerable<Contact>> GetAll()
	{
		try
		{
			await connection.OpenAsync();
			return await connection.QueryAsync<Contact>("select id as Id, first_name as FirstName, last_name as LastName, email as Email, phone_number as PhoneNumber, created_on as CreatedOn, created_by as CreatedBy, updated_on as UpdatedOn, updated_by as UpdatedBy from public.contact");
		}
		finally
		{
			await connection.CloseAsync();
		}
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

		try
		{
			await connection.OpenAsync();
			await connection.QueryAsync("contact_insert", parameters, commandType: System.Data.CommandType.StoredProcedure);
		}
		finally
		{
			await connection.CloseAsync();
		}
	}

	public Task Update(Contact entity)
	{
		throw new NotImplementedException();
	}
}
