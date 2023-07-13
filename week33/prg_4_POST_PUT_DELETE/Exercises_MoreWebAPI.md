### Construct a Custom POST Endpoint



- **Task:** Create a new POST endpoint with a custom route, response object, and request body. The response should contain status code 201 (indicating a CREATED response).
- **Success Criteria:** Using an HTTP client (like Swagger), you should be able to send JSON and receive a 201 response.

**Objective:** Learn to transfer JSON as payload to an endpoint, understand how to set a custom route, use parameter binding from JSON to a C# object (and also serialization + deserialization), and learn how to set a status code.

---

### Build a GET Endpoint with a Custom Data Transfer Object (DTO)

**Objective:** Understand how to pass query parameters and parameter bind them to a custom class using ([FromQuery] ClassName objectIdentifier).

- **Task:** Construct a new GET endpoint that accepts an input/parameter of a custom type (data transfer object). This object should bind parameters from two or more query parameters (not the payload/body). The HTTP response body should include the data transfer object.
- **Success Criteria:** You should be able to send an HTTP GET request with query parameters (api/route?queryparam=value&otherqueryparam=othervalue) and receive a JSON response containing the exact query parameters.

---

### Implement Data Annotations for the DTO


- **Task:** Set up Data Annotations for the Data Transfer Object from the previous exercise. Ensure that you either use the [ApiController] attribute for the controller class or apply a custom Action Filter or manual trigger using ModelState.IsValid.
- **Success Criteria:** You should receive a status 400 response code when the data annotations are breached.

**Objective:** Perform server-side validation of client data—in this case, client data supplied inside of the query parameters instead of payload/body.



---

### Create a Header-Reading Endpoint 



- **Task:** Construct an endpoint that reads from a request header named `supercoolrequestheader`. Respond with a header named `supercoolresponseheader`, with the value taken from the request header "supercoolrequestheader".
- **Success Criteria:** You should receive the same value back using the specified request header.

**Objective:** Learn how to read from and write to request and response headers, including "self-named" headers.

