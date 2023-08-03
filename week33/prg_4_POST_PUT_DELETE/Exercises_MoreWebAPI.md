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

---


### Make custom data annotations

---

### Make a custom DTO response class

---

### Make a CRUD web API with in-memory database