using VFace.Application.Contracts.Test;

namespace VFace.Infrastructure.Test
{
    public interface ITestRepository
    {
        public Task<Guid?> Create(CreateDTO createDTO);
    }
}
