#### Semester info is found here on Moodle:
https://moodle.easv.dk/course/view.php?id=2906

### THE TECH STACK FOR THE ENTIRE SEMESTER
 These are the stuff we'll be using (and with optional links to where these can be installed):

- PostgreSQL (Get a fully managed DB server for free here: https://www.elephantsql.com/ [No payment details required]). You can also download postgres locally on your machine and use that if you wish to be completely offline (fully free and open source)
- .NET 8 https://dotnet.microsoft.com/en-us/download/dotnet/8.0 
- Nodejs 18.x (install latest LTS version using Node Version Manager, see recommended tools below)
- Angular 16 (install using npm bundled with Nodejs)
- Ionic 7 (install using npm bundled with Nodejs)
- Postman HTTP Client ( https://www.postman.com/downloads/ )
- Github for Actions (For CI/CD) (You don't need a paid plan)

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

---

### Important links
- The "single source of truth" for course content for both Programming II and Systems Development II: 
https://github.dev/uldahlalex/3rd-semester-exercises (I recommend you clone this one. If I make any contributions, you can always pull my changes)
- Playlist with videos for this course: https://www.youtube.com/playlist?list=PL10w4feZfunrIXJWTAtCgwOWCBhezxZlS


**Calendar links:**

- Danish calendar: https://tinyurl.com/easvdanish

- Danish ICS link: https://tinyurl.com/icsoutlooklink

- International calendar: https://tinyurl.com/easvinternational

- Intenational ICS link: https://tinyurl.com/icsoutlookint

---

### How the course is taught

Programming II (and Systems Development II for that matter) will be taught as a mixture of these elements:

- **Presentations** (Introducing new topics, verbal and partly visual, mostly non-participating) 

- **Exercises** (Repetitive, shorter duration, smaller domain area, focused)

- **Projects** (Longer running, in-depth, business-oriented problem solving, many participating domain areas, participating, but lacks "repetition") *[Week 35 project, compulsory assignment, exam projcet]*

- **Literature / documentation** (In-depth and informative, but non-participating)

- **Video-based content** (Walkthrough-based, demonstrating, hands-on)

It is my personal philisophy that mixing all 5 styles is beneficial for your learning outcome. I acknowledge personal working/studying preferences, and try to keep all styles of learning present throughout all major topics covered. 

### My recommendations for taking this course



### Stuff i left out (aka. what I wish we had time for)
- Containerization (Docker, Kubernetes, etc. This is covered in 4th semester DevOps and the bachelor's programme)
- "esoteric" request and response formats and HTTP verbs (we'll stick to GET, POST, PUT, DELETE and mostly work with JSON format)
- API versioning (Covered in 4th semester Full-stack)
- We'll work a lot with async in the frontend, but primarily I'll demonstrate synchronous programming on the backend.
- The course does not aim to make you an excellent Javascript developer, but functions as an introduction to making modern Javascript applications using an SPA framework (Angular).
- We will cover just enough HTML and light CSS to be able to use Angular.
- 