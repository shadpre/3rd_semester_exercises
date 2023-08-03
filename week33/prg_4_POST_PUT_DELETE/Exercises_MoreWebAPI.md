### Get started with Postman

**Task:** Go through the "Get started" section subtopics:
- Welcome to Postman
- Postman first steps
    - Overview
    - Get the Postman app
    - Send your first APi request

Then move on to "sending requests", subtopics:
- Building requests
- Receiving responses
- Grouping requests in collections
- Using variables
https://learning.postman.com/docs/getting-started/first-steps/overview/

**Success criteria:** You should feel somewhat comfortable with using Postman to send HTTP requests.

**Learning objective:** The basics of navigating and using Postman to send HTTP requests and analyze responses.

### Construct a Custom POST Endpoint


**Task:** Create a POST endpoint that takes a JSON body/payload and deserializes as a custom C# object. Return with 201 response + the same JSON as client sent.
**Success Criteria:** Using an HTTP client (like Swagger), you should be able to send JSON and receive a 201 response along with the same body.

**Learning objective:** You must know to make a POST endpoint that takes a custom DTO in the payload.

---

### GET with Custom (DTO) composed of different query params

**Task:** Construct a new GET endpoint that accepts an input/parameter of a custom type (data transfer object). This object should bind parameters from two or more query parameters (not the payload/body). The HTTP response body should include the data transfer object. (
```c#
[FromQuery] MyClass myObject
```
).

**Success Criteria:** You should be able to send an HTTP GET request with query parameters (api/route?queryparam=value&otherqueryparam=othervalue) and receive a JSON response containing the exact query parameters.

**Learning objective**: Using more complex parameter binding.

---

### Implement Data Annotations for the DTO


**Task:** Request a custom DTO. The DTO must have data annotations. Return 400 if the validation rules are violated. (Use [ApiController] attribute for the controller for "automatic" validation check)
**Success Criteria:** You should receive a status 400 response code when the data annotations are violated.

**Learning Objective:** Perform server-side data validation of client data.

---

### [ApiController] and exceptions

**Task:** Annotate a controller class with the [ApiController] attribute.
Return a "Bad request" response to a client by throwing an exception.

**Success criteria:** You should get a 400 status code (Bad request).

**Learning objective**: You should be able to make use of the [ApiController] attribute in order to send appropriate responses to the requester.

---

### Make custom data annotations

**Task:** Make data annotations for a request DTO class. Now make a request that will make the data validators fail while using [ApiController].

**Success criteria:** A request that you expect to fail should return a 400 Bad Request status code. (without an exception being thrown)

**Learning objective:** You must know how to perform server-side data validation using Data annotations and return appropriate responses based on this.

---


### Make a CRUD web API with in-memory database

**Task:** Now that you know the basics of making API's, make a Web API which performs basic CRUD operations (without a database - just keep the data in memory).

The following features should be supported:

- Create new data
- Delete data
- Update data
- Get data

Basic server-side data validation must be existent (return status code 400 if your "rules" are violated).