using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;

namespace gettingstarted;

/// <summary>
/// Måske skal dette være en .md med assignment beskrivelse uden unit tests
/// </summary>
public class MyController : ControllerBase, IYourControllerMustDoThis
{
    [HttpGet]
    public object MyEndpoint()
    {
        return new { MyKey = "MyValue" };
    }

    [HttpGet]
    public void ManuallyModifyStatusCodeUsingHttpContext()
    {
        HttpContext.Response.StatusCode = 314;
    }

    [HttpGet]
    public ActionResult ReturnActionResultWithStatusCode200AndObject()
    {
        return Ok(new { Key = "Value" });
    }

    [HttpGet]
    public ActionResult Return404NotFoundWithStringMessage()
    {
        return NotFound("Could not be found");
    }
}

public interface IYourControllerMustDoThis
{
    object MyEndpoint();
    void ManuallyModifyStatusCodeUsingHttpContext();
    ActionResult ReturnActionResultWithStatusCode200AndObject();
    ActionResult Return404NotFoundWithStringMessage();
}


public class HomeControllerTest
{
    MyController _controllerMustDoThis;

    [SetUp]
    public void Setup()
    {
        _controllerMustDoThis = new MyController();
    }


    [Test]
    public void GetResponse_Test() 
    {
        var result = _controllerMustDoThis.MyEndpoint();
    
        Assert.IsNotNull(result);

        var jsonString = JsonConvert.SerializeObject(result);
        var responseObject = JObject.Parse(jsonString);

        Assert.AreEqual("MyValue", responseObject["MyKey"].Value<string>());
    }

    [Test]
    public void ManuallyModifyHttpContext_Test()
    {
        // Arrange
        var mockHttpContext = new Mock<HttpContext>();
        var responseMock = new Mock<HttpResponse>();
        var memStream = new MemoryStream();
        responseMock.SetupAllProperties();
        responseMock.SetupGet(r => r.Body).Returns(memStream);
        mockHttpContext.SetupAllProperties();
        mockHttpContext.SetupGet(a => a.Response).Returns(responseMock.Object);
        _controllerMustDoThis.ControllerContext.HttpContext = mockHttpContext.Object;

        // Act
         _controllerMustDoThis.ManuallyModifyStatusCodeUsingHttpContext();

        // Rewind the memory stream and convert it to a JObject
        memStream.Position = 0;

        // Assert
        Assert.AreEqual(314, _controllerMustDoThis.HttpContext.Response.StatusCode);
        // Further asserts based on response body...
    }
}