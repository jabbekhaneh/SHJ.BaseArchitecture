using SHJ.BaseArchitecture.Application.Contracts.Dynamic.DTOs;
using SHJ.BaseArchitecture.Application.Test.Configurations;
using SHJ.BaseArchitecture.Shared;
using SHJ.ExceptionHandler;

namespace SHJ.BaseArchitecture.Application.Test.Dynamic;

public class PageAppServicesTest : BaseApplicationTest
{

    public PageAppServicesTest(DockerWebApplicationFactoryFixture factory) : base(factory)
    {

    }

    [Fact]
    public async Task Create_Page_Should_Response_OK()
    {
        //arrange
        var page = new CreatePageDto
        {
            Title = "Test_Title",
        };

        //act
        var request = await _client.PostAsync(DynamicHelpers.Urls.CreatePage,
            HttpHelper.GetJsonHttpContent(page));

        //assert
        request.StatusCode.Should().Be(HttpStatusCode.OK);

    }
    [Fact]
    public async Task Create_Page_Should_Exception_When_Dublicate_Title()
    {
        //arrange
        var page = new CreatePageDto
        {
            Title = "Test_Title2",
        };
        await _client.PostAsync(DynamicHelpers.Urls.CreatePage,
           HttpHelper.GetJsonHttpContent(page));


        //act
        var response =await _client.PostAsync(DynamicHelpers.Urls.CreatePage,
          HttpHelper.GetJsonHttpContent(page));

        //assert

        var statusCode = (int)response.StatusCode;
        statusCode.Should().Be((int)PortalErrorCodes.DublicatePageTitle);
    }
}
