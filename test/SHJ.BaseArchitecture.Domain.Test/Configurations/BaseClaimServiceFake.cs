using SHJ.BaseFramework.Shared;

namespace SHJ.BaseArchitecture.Domain.Test.Configurations;

public class BaseClaimServiceFake : BaseClaimService
{
    public string GetClaim(string key)
    {
        return "Dummy-Claim";
    }

    public string GetUserId()
    {
        return Guid.NewGuid().ToString();
    }

    public bool IsAuthenticated()
    {
        return false;
    }
}