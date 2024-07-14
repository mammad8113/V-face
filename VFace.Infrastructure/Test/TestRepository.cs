using Dapper;
using VFace.Application.Contracts.Test;

namespace VFace.Infrastructure.Test
{
    public class TestRepository : ITestRepository
    {
        private readonly DapperContext _context;

        public TestRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<Guid?> Create(CreateDTO createDTO)
        {

            using var connection = _context.CreateConnection();
            connection.Open();
            using var transaction = connection.BeginTransaction();

            var tableExists = await connection.QueryFirstOrDefaultAsync<int>(
              "SELECT COUNT(*) FROM T_User WHERE UID=@UID", createDTO, transaction: transaction);

            Guid? result = null;

            if (tableExists <= 0)
            {
                var sql =
                "Insert Into T_User ([UID],NationalCode,[Name],Family,FatherName,[Address],BirthDate,CompanyName,Mobile,GenderId,PostCode)" +
                "OUTPUT INSERTED.UID " +
                "values(@UID,@NationalCode,@Name,@Family,@FatherName,@Address,@BirthDate,@CompanyName,@Mobile,@GenderId,@PostCode) ";


                result = await connection.QuerySingleAsync<Guid>(sql, createDTO, transaction);

                // return result;
            }
            transaction.Commit();
            return result;

        }

    }
}
