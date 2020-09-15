
<img src="https://github.com/diogomatos97/Project/blob/WIP/images/85b65f62-63ca-44d6-b8cd-4315d8805817_200x200.png" style="zoom: 150%;" />

[Sprint 1](#sprint-1)

[Sprint 2](#sprint-2)

[Sprint 3](#sprint-3)

[Sprint 4](#sprint-4)

[Sprint 5](#sprint-5)

[Project Retrospective](#Project-Retrospective)



### Sprint 1

#### Goals

The goal for this sprint is to create the database and start developing the CRUD functionalities and the program logic, including retrieving data and login validations.

#### Review

For this sprint, 4 user stories have been marked as Done, which all correspond to the creation of the database. In addition, 6 other user stories have been added to the review stage, as, although already pre-fulfilled, all are required to go through testing, both automated and manual. This review stage will span throughout the next sprint, as it is important to test the functionalities before starting to develop an Graphical User Interface. It is also important to note that, to fulfil the manual testing, a sample GUI will be created on the next sprint to conclude that all functionalities are working according to the requirements.

##### Entity Relationship Diagram

![](https://github.com/diogomatos97/Project/blob/WIP/images/erd.PNG)

##### Business Rules Diagram

![](https://github.com/diogomatos97/Project/blob/WIP/images/BusinessRules.png)

#### Retrospective

During the sprint, It has been noticed that, while preparing and planning the sprint, the number of tasks to be completed have been underestimated. This means that initially only 3 user stories have been selected from the product backlog when, in reality, 9 user stories have been passed to the in progress section. Also, this sprint has presented two blockers which were: not using the correct syntax for the creation of the database (using MySQL instead of SQL), which caused errors with the primary keys; not remembering how to use LINQ method syntax for method join queries, where the solution was to use the query syntax. 

#### Sprint Breakdown

##### Start of Sprint

![](https://github.com/diogomatos97/Project/blob/WIP/images/sprint1am.PNG)

##### End of Sprint

![](https://github.com/diogomatos97/Project/blob/WIP/images/sprint1pm.PNG)

### Sprint 2

#### Goals

The goal for this sprint is to create the tests for the CRUD functionalities and adapt the code so that all tests can pass.

#### Review

For this sprint, 7 user stories have been marked as Done, which correspond to the CRUD functionalities that have passed through testing. In addition, 2 other user stories have been added to the project backlog and have been marked as done, since all have met the acceptance criteria that require tests to pass. During this sprint, not all user stories from the Review tab have been marked has done since the tests have not yet passed, which will lead to code inspection and code modification. This makes the goal for the following sprint to finish modifying the code and start developing the visual interface, to meet the MVP definition of done.



#### Retrospective

During the sprint, I have noticed that testing is an area that requires more that 1 day to complete as, when showing flaws in the code, it can lead to stress and anxiety. It has also been noticed while testing that, due to the lack of extended knowledge on the Microsoft Entity framework, there have been problems with the test run, due to tests not running in parallel or in a specific order. For the following sprints, I plan to improve on how I plan the amount of tasks required to complete, accounting for the worst case scenarios where things might not go as planned. This will help as, if things go south, I will have more time to focus on the individual tasks and be in a more healthier environment.
As to improve for following projects, I will plan more than 1 sprint to create unit tests so that I can work with more time and have a less stressing environment.

#### Sprint Breakdown

##### Start of Sprint

![](https://github.com/diogomatos97/Project/blob/WIP/images/sprint2am.PNG)

##### End of Sprint

![](https://github.com/diogomatos97/Project/blob/WIP/images/sprint2pm.PNG)

### Sprint 3

#### Goals

The goal for this sprint is to finish creating the unit tests for the CRUD functionalities and start to develop the user interface.

#### Review

For this sprint, I have moved 2 user stories from the review tab to done, as all the acceptance criteria have been met and the tests have passed. During this sprint, I also started to develop a simple user interface to do manual testing on the login functionalities, and developing the pages where the content is shown, as to see if everything is working. Later on the day, I started to change the User Interface design, as so it looks more appealing to the user.
Regarding this sprint, I faced similar blockers to the pervious one as, when testing the entity framework, tests would sometimes not pass due to update conflicts. I have also not been able to get passing tests on my update functionalities as, although when manual tested the code works, the code does not seem to fetch the updated data when under tests.



#### Retrospective

As to improve on the following sprints, there are no new subjects I need to improve or approach in a different method, as this sprint was similar to the previous one. This means that the work done has been almost identical, therefore no new problems have surfaced.

#### Sprint Breakdown

##### Start of Sprint

![](https://github.com/diogomatos97/Project/blob/WIP/images/sprint2pm.PNG)

##### End of Sprint

![](https://github.com/diogomatos97/Project/blob/WIP/images/sprint3pm.PNG)


### Sprint 4

#### Goals

The goal for this sprint is to continue developing the user interface for the WPF application.

#### Review

For this sprint, I have remained with the 2 last user stories on my sprint backlog, as both are related to the user interface, making it only able to complete once the UI has been developed. During this sprint I have also moved on user story regarding the artist list, as the interface is now returning and updating the list of artists for a manager.
The Blocker for this sprint was the lack of knowledge on visual controls to create a user interface, making the development a trial and error situation.



#### Retrospective

As to improve on the following sprints I intend to focus on more on implementing the MVP DOD instead of focusing on the visuals of the User Interface.

#### Sprint Breakdown

##### Start of Sprint

![](https://github.com/diogomatos97/Project/blob/WIP/images/sprint2pm.PNG)

##### End of Sprint

![](https://github.com/diogomatos97/Project/blob/WIP/images/sprint3pm.PNG)



### Sprint 5

#### Goals

The goal for this sprint is to complete the Minimum Viable Product Definition of Done, meaning that all the requirements to have a working application have been completed and met.

#### Review

For this sprint, I have sent the last 2 user stories to the Done tab, as the all user interface controls have been added and the applications has been manually tested. In this sprint I did not encounter any blockers as all I had planned for this sprint was to clean the user interface and add a media element to play an artist song, where the code was based on previous projects (Radio Project). 

#### Retrospective

During this last sprint, I have appreciated how I have planned the last 2 sprints, as I was able to have an early focus on the logic and interface design. Once the initial points were achieved, I was then able to just add to what I add, both on the logic, for additional methods that were needed to present the functionality, and on the user interface, where once the initial design was done, I was able to build upon it and slightly make changes.

#### Sprint Breakdown

##### Start of Sprint

![](https://github.com/diogomatos97/Project/blob/WIP/images/sprint5am.PNG)

##### End of Sprint

![](https://github.com/diogomatos97/Project/blob/WIP/images/sprint5pm.PNG)



### Project Retrospective

The initial goal for this project was to develop a 3 tier application that made music management easier. Regarding the project development process, there are a few points of the approach that deserve appraise and other that could be improved. The main point that has shown to be successful was the idea of creating a business logic diagram so I would have a base to build the program logic upon. In addition, this allowed me to focus on logic development, as it was important for me to have a starting point of development, which kept me with high motivation to keep developing the application. This also applied to the User Interface, as when blocked, my approach was to start sketching on what I would like to see on an application of this type. 

The point to improve on future projects is to take into account the Unit test part of software development. As specified on my sprint review, when encountered with testing, I was not able to remain calm and ended up creating a stressful environment. This was due to some functionalities not being able to pass the tests, although working when manual tested. Also, as the program logic was already created, it made it harder to change the logic as to make the tests pass, since it could break the existing code. As to improve, I would advise myself to perform unit tests in parallel with the logic development, as it would be easier to modify and adapt the code.

Overall, this project allowed me to develop my C# Skills, both on backend and frontend.

