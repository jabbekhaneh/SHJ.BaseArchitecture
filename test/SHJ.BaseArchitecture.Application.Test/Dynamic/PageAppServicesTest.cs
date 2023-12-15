using SHJ.BaseArchitecture.Application.Contracts.Dynamic.DTOs;
using SHJ.BaseArchitecture.Application.Test.Fixtures;
using SHJ.ExceptionHandler.http;
using System.Net.Http.Json;

namespace SHJ.BaseArchitecture.Application.Test.Dynamic;

public class PageAppServicesTest : BaseControllerTests
{

    public PageAppServicesTest(IntegrationContainersAppFactory factory) : base(factory)
    {

    }


    public readonly static string CreatePageUrl = "/api/Page";

    [Fact]
    public async Task Create_Page_Should_Response_OK()
    {
        //arrange
        var page = new CreatePageDto
        {
            Title = "Test_Title",
        };

        //act
        var response = await RequestHttp.PostAsync(CreatePageUrl, HttpHelper.GetJsonHttpContent(page));

        //assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

    }
    [Fact]
    public async Task Create_Page_Should_Exception_When_Dublicate_Title()
    {
        //arrange
        var page = new CreatePageDto
        {
            Title = "Test_Title2",
        };
        await RequestHttp.PostAsync(CreatePageUrl,HttpHelper.GetJsonHttpContent(page));


        //act
        var response = await RequestHttp.PostAsync(CreatePageUrl,HttpHelper.GetJsonHttpContent(page));

        //assert
        response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
    }
}
