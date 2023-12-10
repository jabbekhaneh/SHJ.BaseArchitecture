
using SHJ.BaseArchitecture.Application.Contracts.Dynamic.DTOs;
using SHJ.BaseArchitecture.Application.Test.Configurations;

namespace SHJ.BaseArchitecture.Application.Test.Dynamic;

public class PageAppServicesTest : BaseApplicationTest
{
    
    public PageAppServicesTest(DockerWebApplicationFactoryFixture factory) : base(factory)
    {

    }

    [Fact]
    public async Task Create_Page()
    {
        //arrange
        var page = new CreatePageDto
        {
            Title="Test_Title",
        };

        //act
        var request= await _client.PostAsync(HttpHelper.Urls.CreatePage,
            HttpHelper.GetJsonHttpContent(page));

        //assert
        request.StatusCode.Should().Be(HttpStatusCode.OK);

    }
}
