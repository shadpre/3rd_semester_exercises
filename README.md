#### 👨‍💻Greetings, fellow devs!👨‍💻

These are all of the course content for the entirety of Programming II & Systems Development II.
(If you're reading this on Moodle, the repository is located here: https://github.com/uldahlalex/3rd_semester_exercises/  The markdown files from the repository are simply embedded into Moodle)

The structure of this repository is the following:
- Weeks are divided into individual "days", like "programming day 1" or "systems development day 2" of that particular week.
- Each day will have a README.md file(embedded into Moodle) with the info about that particular day (presentation topics, links, documentation, etc.) The Exercises, however, must all be accessed from the repository.

I recommend you clone the repository 
```
git clone https://github.com/uldahlalex/3rd_semester_exercises
```
So you can take advantage of the exercise setups I have made *(such as tests to validate your work)*.

You can also view the repository in an online editor if you just want a quick view without downloading: https://github.dev/uldahlalex/3rd_semester_exercises

Semester info is still on Moodle here: https://moodle.easv.dk/course/view.php?id=2906

I recommend starting out by reading (or at least having a quick glance at) this file to get some basic info about this Programming II and Systems Development II.


**Best regards,**<br>
**Alex**


# THE TECH STACK
 These are the stuff we'll be using (and with optional links to where these can be installed):

 <details  style="margin: 25px;">
  <summary><b style="font-size: 25px">Click here to see full list</b></summary>

- PostgreSQL (Get a fully managed DB server for free here: https://www.elephantsql.com/ [No payment details required]). You can also download and run postgres locally on your machine (I also left a docker-compose.yml file in the root folder if anyone wants to run using Docker).
- .NET 8 https://dotnet.microsoft.com/en-us/download/dotnet/8.0 
- Nodejs 18.x (install latest LTS version using Node Version Manager, see recommended tools below)
- Angular 16 (install CLI using npm bundled with Nodejs)
- Ionic 7 (install CLI using npm bundled with Nodejs)
- Postman HTTP Client ( https://www.postman.com/downloads/ )
- Github for Actions (For CI/CD) (You don't need a paid plan - any Github account is fine)
- Playwright E2E testing (available on npm)
- Microsoft Azure (cloud service, sign up using "Azure for students" for a generous 12 month free tier)

Tools i recommend installing that will make your lives easier:
- Node version manager: 
LINUX / MAC, Follow instructions in README.md: https://github.com/nvm-sh/nvm
WINDOWS: download the nvm-setup.exe from here: https://github.com/coreybutler/nvm-windows/releases/tag/1.1.11 and run it
- Rider: Install using Jetbrains Toolbox (just like IntelliJ)
- Datagrip: Install using Jetbrains Toolbox (just like IntelliJ)
- Git bash(For Windows users) (you probably already have it since it's commonly installed along with Git)

A couple notes on tech stack decisions for those who are interested:
- I generally prefer free and open source software, and want to give you the possibility to run your programs locally and offline before you deploy(hence why PostgreSQL). 
- Everything I push is cross operating system compatible, and you can use just about any machine and operating system in the world without any difficulties. 
- The most demanding programs are Rider and Datagrip - if these are too demanding for your machine, I recommend installing VS Code and using extensions instead of a full-fledged IDE, since it can run on much fewer resources: https://code.visualstudio.com/ 



</details>


---

### Important links
- The "single source of truth" for course content for both Programming II and Systems Development II: 
https://github.dev/uldahlalex/3rd_semester_exercises (I recommend you clone this one. If I make any contributions, you can always pull my changes)
- Playlist with videos for this course: https://www.youtube.com/playlist?list=PL10w4feZfunrIXJWTAtCgwOWCBhezxZlS

- Official orders: https://www.easv.dk/app/uploads/academic-regulations/education/3050-2022-1-Computer%20Science.pdf
(see the Systems Development 2 and Programming 2 sections for specific info about these courses)

**Calendar links:**

*Please note that the Outlook UI sometimes defaults to starting weeks on Sundays instead of Mondays, so remember to read the weekday carefully:*

The time-tables can also be read on Moodle under general semester info (not the individual course pages).

- Published Danish calendar (web): https://tinyurl.com/easvdanish

- Danish ICS link: https://tinyurl.com/icsoutlooklink

- Published International calendar (web): https://tinyurl.com/easvinternational

- Intenational ICS link: https://tinyurl.com/icsoutlookint



---

### Aim of the courses

Although the learning goals are expressed in the official orders, I want to give a more straight-forward explanation of what you will learn:

You will learn how to build software systems comprised of dedicated front- and backend applications geared towards modern web consumption. There is a heavy emphasis on processes like automation, testing and software delivery. 


---


### How the course is taught

Programming II (and Systems Development II for that matter) will be taught as a mixture of these elements:

- **Presentations** (Introducing new topics, verbal and partly visual, mostly non-participating) 

- **Exercises** (Repetitive, shorter duration, smaller domain area, focused)

- **Projects** (Longer running, in-depth, business-oriented problem solving, many participating domain areas, participating, but lacks "repetition") *[Week 35 project, compulsory assignment, exam projcet]*

- **Literature / documentation** (In-depth and informative, but non-participating)

- **Video-based content** (Walkthrough-based, demonstrating, hands-on)

It is my personal philosophy that mixing all 5 styles is beneficial for your learning outcome. I acknowledge personal working/studying preferences, and try to keep all styles of learning present throughout all major topics covered. 

### Contact & Help

I can always be reached by mail at aup@easv.dk (please don't message me on Moodle)

For tutor help, please contact the always knowledgeable, Tomas Sirotek via Discord: https://discordapp.com/users/707641281215725689 
He can also be reached via email: toma2509@easv365.dk

---
### FAQ
Q: Can I have your slides?
- My presentation slides are public (published just after end of presentations), since I want transparency. However, I don't recommend you bother "reading" slides. They simply exist in order to guide my presentations. If you want to read, please see the relevant literature+documentation for each lecture.

---

### Stuff i left out (aka. what I wish we had time for)
- Containerization (Docker, Kubernetes, etc. This is covered in 4th semester DevOps and the bachelor's programme)
- "alternative" request and response formats and HTTP verbs (we'll stick to GET, POST, PUT, DELETE and mostly work with JSON)
- API versioning (Covered in 4th semester Full-stack)
- We'll work a lot with async in the frontend with Promises, but primarily I'll demonstrate synchronous programming on the backend.
- The course does not aim to make you an excellent Javascript developer, but functions as an introduction to making modern Javascript applications using a framework (Angular).
- We will cover just enough HTML and light CSS to be able to use Angular.
- We don't cover other types of API's than HTTP-based REST(-ish). (No gRPC, MQTT, SOAP, GraphQL, Kafka, Websockets. *Some of these may be covered in a very interesting elective subject I have in the works for 4th semester, though...🕵️)*
- Noteworthy Nuget packages (.NET libraries) commonly used in enterprise IT I decided to leave out due to time constraints/better alternatives/not fit for course needs are the following (You may use these if you like for exam and projects, but I don't include these in lectures):
    - Automapper (And any other Mapping library for that matter)
    - Mediatr
    - Fluent Validation (I use Data Annotations validation)
    - Entity Framework (I use Dapper)
    - (more will probably make this list)
