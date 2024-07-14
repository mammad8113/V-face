using VFace.Framwork;

namespace VFace.Application.Contracts.Test
{
    public interface ITestApplication
    {
        public Task<ResponseModel> Create(CreateDTO createDTO);
    }
}
