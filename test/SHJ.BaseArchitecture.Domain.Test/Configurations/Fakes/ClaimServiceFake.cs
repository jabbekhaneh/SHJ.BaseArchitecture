using SHJ.BaseFramework.Shared;

namespace SHJ.BaseArchitecture.Domain.Test.Configurations.Fakes;

public class ClaimServiceFake : BaseClaimService
{
    public string GetClaim(string key)
    {
        return "Fake_Claim";
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
