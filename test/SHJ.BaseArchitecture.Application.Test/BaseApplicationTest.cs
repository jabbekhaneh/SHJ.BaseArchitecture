using SHJ.BaseArchitecture.Application.Test.Configurations;

namespace SHJ.BaseArchitecture.Application.Test;

public abstract class BaseApplicationTest : IClassFixture<DockerWebApplicationFactoryFixture>
{
    private readonly DockerWebApplicationFactoryFixture _factory;
    protected readonly HttpClient _client;
    public BaseApplicationTest(DockerWebApplicationFactoryFixture factory)
    {
        _factory = factory;
        _client = _factory.CreateClient();
    }

}

