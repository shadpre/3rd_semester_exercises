### Exercise: Set an environment variable

**Task**: Follow my guide in the README.md file to set a system-wide environment variable.

**Success criteria**: When running a .NET application and using Environment.GetEnvironmentVariable(string),
you should be able to log the environment variable to the console (or use for any other purpose).

**Learning objective:** It is vital that any developer knows how to securely set an environment variable, so you don't hardcode environment data straight into the source code. (especially secrets/passwords/etc.)

---

### Exercise: Set an environment variable for your IDE *(often done for unit tests)*

**Task**: Task guide for Rider, go to Settings -> Build, execution, deployment -> Unit testing -> Test runner. Scroll down to environment variables, add an environment variable.
*Remember to .gitignore whatever file your environment variable is being written to*

**Success criteria**: Make an independently executable test, and try to log the environment variable inside of the test. You should get the value just like when using system-wide or terminal emulator environment variables.

**Learning objective:** When running tests, you may use another execution, and therefore require a different environment variable setup.

---

### Exercise: Add a singleton service, and require this



---


### Comparing service lifetimes

**Task**: Make services with different lifetimes (singleton, transient, scoped). These services should log to the console in their constructors *(like: "hello from singleton service X")*. Now require all these services in a controller class, and start sending requests to an endpoint in the controller.

**Success criteria:** You should for instance notice the following:
- The singleton service is constructed once, and never logs the string again, whereas the scoped service is constructed for each request.

**Learning objective**: You should be familiar with the difference between service lifetimes.



---

### Exercise: Request a service injected into the WebApplicationBuilder from the WebApplication.


---


### Exercise: Assess your progress

If you've made it this far, you should be ready for next week, where we're starting to work with Dapper.

I want want to invest more time into sharpening your skills, try to identify one of these areas you want to improve, and follow the resources I linked:

- Writing algorithms with C#:
- Recapping some relational DB theory with PostgreSQL before starting Dapper: 
- Becoming better with Bash CLI:
- Sharpening API skills: 