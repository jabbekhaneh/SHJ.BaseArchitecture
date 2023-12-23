using SHJ.BaseArchitecture.Application.Contracts.Dynamic.DTOs;
using SHJ.BaseArchitecture.Application.Test.Configurations.Fixtures;

namespace SHJ.BaseArchitecture.Application.Test.Dynamic;

public class PageAppServicesTest : BaseControllerTests
{

    public PageAppServicesTest(IntegrationContainersAppFactory factory) : base(factory)
    {

    }


    private readonly static string _Sut = "/api/v1/Page";

    [Fact]
    public async Task OnCreatePage_WhenExecuteController_ShouldReturnOk()
    {
        //arrange
        var page = new CreatePageDto
        {
            Title = "Dummy",
        };
        //act
        var response = await RequestHttp.PostAsync(_Sut, HttpHelper.GetJsonHttpContent(page));

        //assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

    }

    public async Task OnUpdatePage_WhenExecuteController_ShouldReturnOk()
    {
        //arrange
        var page = new UpdatePageDto
        {
            Title = "Dummy",
        };
        //act
        var response = await RequestHttp.PutAsync(_Sut, HttpHelper.GetJsonHttpContent(page));

        //assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

    }
}
