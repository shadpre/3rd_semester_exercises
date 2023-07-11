Greetings devs!

For this assignment, you must provide functionality to a frontend application I made by providing the backend. (A news feed)

The frontend sends requests to your machine when you go to this address:  https://week35-86108.web.app

Now it is your responsibility to create an API running on http://localhost:5000 responding to these requests.

How do you know that your backend is doing what it's supposed to? I've made a suite of API tests using Postman (a collection in JSON format). You can import these tests into your Postman HTTP client or run with the Newman CLI. Once all the tests pass, you should have a fully functional full-stack app when navigating to the frontend URL.  (The program can also be functional without all the API tests passing, but they should be a guide)
The JSON file is located ./Resources/MakeABackendForThisFrontendApiTests.json


These are the expectations for the API:
It should be possible to get a list of recent news stories on the landing page (a feed).
[ GET http://localhost:5000/api/feed ]
These posts should only include some of the article text (body): a max of 51 characters is allowed here (article body texts can be very long, but on the scrollable news feed we just want snippets of the articles)

It should be possible to get the full article with all details
[ GET http://localhost:5000/api/articles/{articleId} ]

It should be possible to delete an article (don't worry about role authorities, "anyone" should be able to do this)
[ DELETE http://localhost:5000/api/articles/{articleId} ]
When responding with a successful status code, the frontend app assumes it can remove the article from the frontend.

It should be possible to update an article (don't worry about role authorities, "anyone" should be able to do this).
[ PUT http://localhost:5000/api/articles/{articleId} ]
The client will send the full article JSON in the body to replace the current article.
The API should respond with the full updated article.
The following server side validation rules should apply:
Headline must be between 5 and 30 characters (inclusive)
The body can be up to 1000 characters
The news media only has 4 journalists: Bob, Rob, Dob, Lob, and the author should be one of these.

It should be possible to create a new article (don't worry about role authorities, "anyone" should be able to do this).
[ POST http://localhost:5000/api/articles/{articleId} ]
The client will send the full article as a JSON in the body.
The API should respond with the full article JSON including generated ID (authorId).
The server side validation rules for creating are the same as for updating an article.

It should be possible to search for articles.
[ GET http://localhost:5000/api/articles?searchterm=X?pagesize=X ]
The client will include the search term in the query params. The search term should not require an "exact match", but rather if an article includes a search term somewhere (or anything close to it).
The client will list the page size in the query params. (Hint: use LIMIT postgres keyword)
The search term should be at least 3 characters, and page size at least 1.
The articles should just include the articleId, author and headline.

All responses should follow the JSON format with { "messageToClient": "sometext", "responseData": { } } being the consistent return data transfer object.

If there is any confusion, please take a closer look at the API tests (import into Postman from JSON) - the tests will be very descriptive of what the API should do.

I also made a small video showing the application running with a working backend:
https://drive.google.com/file/d/1dgtCAWYUcX-tnxnN-MywxyMSwOFewmgm/view?usp=sharing

Some notes about completing this assignment:
- The API tests (or the frontend app for that matter) do not know whether you actually persist data or just respond using "in-memory" data like an array. I recommend setting up a database and making queries with Dapper. However, the app can run without.
- You do not have to look at the test code. The tests are written in Javascript. We will start looking at Javascript when we start programming frontend. You only have to look at whether or not the tests pass (the test title should be descriptive enough).
- I will release a guided solution (the one displayed in the video) by the end of the week.
- Remember to enable CORS in Program.cs so your requests don't get rejected.
- This is not a compulsory assignment, but I strongly suggest finishing it.
- I have decided to share my DB schema for my solution demonstrated in the video. You can design your own or use mine to get started: (text is highlighted - it is not an image)


CREATE SCHEMA news
CREATE TABLE news.articles(
article_id serial constraint articles_pk primary key,
headline text,
body text,
author text,
article_img_url text
)

