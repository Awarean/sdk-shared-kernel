using System;
using Awaren.Sdk.SharedKernel;

namespace Awarean.Sdk.SharedKernel.Tests.Fixtures
{
    public class MockAuditableEntity : AuditableEntity<Guid>
    {
        public string Data { get; set; } = string.Empty;
        public void MockUpdate(string updated, string newData)
        {
            Data = newData;
            Update(updated);
        }

    }
}