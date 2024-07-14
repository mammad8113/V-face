using VFace.Application.Contracts.Test;
using VFace.Framwork;
using VFace.Infrastructure.Test;

namespace VFace.Application.Test
{
    public class TestApplication : ITestApplication
    {
        public ITestRepository testRepository { get; set; }

        public TestApplication(ITestRepository testRepository)
        {
            this.testRepository = testRepository;
        }

        public async Task<ResponseModel> Create(CreateDTO createDTO)
        {
            var data = await testRepository.Create(createDTO);

            return new ResponseModel()
            {
                Data = data,
                Success = true,
                Message = SystemMessage.INF_OperationSuccessed
            };
        }
    }
}
