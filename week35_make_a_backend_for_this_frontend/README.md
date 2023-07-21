# Backend Development Assignment

Greetings, developers! 👨‍💻

# This assignment will be adjusted shortly, so if you're reading this now, be wary it is subject to change

This assignment revolves around extending the functionality of a frontend application by building a corresponding backend. The primary function of this application is to serve as a news feed.

The frontend interacts with your machine via the following address: [https://week35-86108.web.app](https://week35-86108.web.app)

Your task is to develop an API running on [http://localhost:5000](http://localhost:5000), capable of responding to these requests.

To ascertain the correct working of your backend, a suite of API tests (in JSON format) has been prepared using Postman. You can import these tests into your Postman HTTP client or execute them using the Newman CLI. The application will be considered fully functional when all tests pass and the frontend URL is navigated without any errors. The JSON file containing these tests can be found at `./MakeABackendForThisFrontendApiTests.json`. (the .json file in this directory on Github)

## API Expectations

1. **News Feed**: The landing page should display a list of recent news stories. Each post should include a portion of the article text (body) - a maximum of 51 characters.

   Endpoint: `GET http://localhost:5000/api/feed`

2. **Full Article Details**: Users should be able to retrieve the full details of an article.

   Endpoint: `GET http://localhost:5000/api/articles/{articleId}`

3. **Delete Article**: An article can be deleted by any user.

   Endpoint: `DELETE http://localhost:5000/api/articles/{articleId}`

4. **Update Article**: An article can be updated by any user. The updated article JSON is sent by the client to replace the current article. The API should respond with the updated article.

   Endpoint: `PUT http://localhost:5000/api/articles/{articleId}`

5. **Create New Article**: A new article can be created by any user. The new article JSON is sent by the client. The API should respond with the new article JSON, including the generated ID (authorId).

   Endpoint: `POST http://localhost:5000/api/articles`

6. **Search for Articles**: Users should be able to search for articles. The client will include the search term and page size in the query parameters.

   Endpoint: `GET http://localhost:5000/api/articles?searchterm=X&pagesize=X`

### Validation Rules for Create, Update and Search Endpoints

- The headline must be between 5 and 30 characters (inclusive).
- The body can contain up to 1000 characters.
- The author should be one of the following four journalists: Bob, Rob, Dob, or Lob.
- The search term should be at least 3 characters, and the page size at least 1.

All responses should adhere to the JSON format, with `{ "messageToClient": "sometext", "responseData": { } }` being the standard return data transfer object.

For further details, please refer to the API tests that can be imported into Postman from JSON. You can also check out a demonstration of the application with a working backend [here](https://drive.google.com/file/d/1dgtCAWYUcX-tnxnN-MywxyMSwOFewmgm/view?usp=sharing).

## Additional Notes

- The API tests and frontend app won't be aware if you're persisting data or using "in-memory" data like an array. Nonetheless, setting up a database and making queries with Dapper is recommended.
- There's no need to inspect the test code. Focus on whether the tests pass or not.
- A solution guide, as shown in the video, will be available by the end of the week.
- Make sure to enable CORS in Program.cs to avoid request rejection.
- Although this assignment isn't mandatory, it's strongly recommended.
- For your convenience, the DB schema used in the solution demonstrated in the video is provided. You may create your own or use this as a starting point:

```sql
CREATE SCHEMA news
CREATE TABLE news.articles(
article_id serial constraint articles_pk primary key,
headline text,
body text,
author text,
article_img_url text
)