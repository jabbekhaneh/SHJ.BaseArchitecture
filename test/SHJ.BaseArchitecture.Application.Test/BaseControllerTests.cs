using SHJ.BaseArchitecture.Application.Test.Fixtures;

namespace SHJ.BaseArchitecture.Application.Test;

public class BaseControllerTests : IClassFixture<IntegrationContainersAppFactory>
{
    private readonly IntegrationContainersAppFactory _factory;
    public HttpClient RequestHttp { get; set; }
    public BaseControllerTests(IntegrationContainersAppFactory factory)
    {
        _factory = factory;
        RequestHttp = _factory.CreateClient();
    }

}

