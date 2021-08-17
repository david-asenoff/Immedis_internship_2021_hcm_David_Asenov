## About The Project :pencil2:
Human Capital Management App is a task given by <a href="https://immedis.com/"><img src="https://515636-1693170-raikfcquaxqncofqfm.stackpathdns.com/wp-content/uploads/2021/01/favicon.png" alt="immedis logo" width="30"><b>immedis</b></a> as a part of an internship.

## Requirements :scroll:
The application should hold people records, which are the main app entities. The functionality of the app should support creating, listing, editing and deleting people's records, salary information, department. System should have login functionality i.e. security module and at least 2 types of users. The application should persist the data into a databases. Application should be containerized and have at least 2 APIs communicating with each other. Data validation and error handling is a plus but is not mandatory.  Designing the functionality in terms of functionalities and capabilities will depend on you. The goal is to create a production like software that could cover the needs of an HR team in a small/medium company.

## Project description :bulb:
1. The users with an Employee role have the ability to:
* Login or Register
	- in case of Registration one has to use a username and email which are not "already taken".
	- in case of Login if user is banned from Administrator will receive an error message and won't be let to enter.
	- in case of successful Login he will receive success message.
	- success and error messages are included for all pages.
* Account pages which consist:
	- Dashboard with stats of his effective contracts, in other words contracts without an end date.
	- Profile with his personal data, contacts and profile picture. All of the above may be updated.
	- Logout to exit from his profile.
* Service pages which consist of:
	- Requested Leaves page - user may create a request for leave with start and end date, and point out whether to be a paid one or not.
User may also edit his request only if Manager hadn't approved it yet. User may also delete his request only if Manager hadn't revised it yet. In case of successful deletion Manager won't see the request in his log.
	- Contracts page can't be updated or deleted by an employee, and he can only see the details about his contract.
	- Projects page show a list of the projects he participate in. Just as the previous page he can just see some details about it without being able to change its values.

2. The users with a Manager role have the ability to:
* Login, Logout and Profile just as the Emlpoyee
	- Manager cannot be registered. Manager role is given only by an Administrator. The default role that is going to be given with the registration is Employee role.
* Account pages 
	- Profile and Logout pages are with the same functionalities
	- The Dashboard page will grant him some summary about all the Companies in the application.
* Employee pages
	- Leave requests page which will defer from the Employee one. Manager may resolve the requests by Approve them, Decline them or just keep them as Pending for Approval. The status will change for the respective Employee and his request too.
	- Participants in training page - Manager may update the information about the training and the list of the participants in it.
	-  Employee contracts page - Manager may end a Contract, which will add an End date to it and be considered as a concluded contract.
Manager may change the Department, Position taken, Payment interval, currency, net and gross salary, start and end dates of the contract, working hours, whether is with flexible working hours and a full time contract. He may also edit the allowed leaves per year.
* Projects pages
	-  Participants in projects page works just as „Participants in trainings“ page
	-  Projects statuses page - Manager may change the status to completed, on hold, in progress, canceled or not started. He can also change the start and end date of a project. A project has a list of statuses.
* Data pages
	- Manager may create, edit and delete the Trainings, Addresses, Departments, Departments Addresses and Companies information.

3. The users with an Administrator role have the ability to:
* Use the Account pages just as the Manager and Employee.
* Use the Data pages just as the Manager.
* Use the User pages from where he can ban users.
* Use the Administrator only pages to create, edit and delete Currencies, Genders, Payment intervals, Evaluation scores, Marital statuses, Parental statuses and Project status Categories.
  
## Test accounts :closed_lock_with_key:
* Administrator
````
Username: 'Administrator'
Password: '123456'
`````
* Manager
````
Username: 'Manager'
Password: '123456'
`````
* Employee
````
Username: 'username0'
Password: '123456'
Username: 'username1'
Password: '123456'
...
Username: 'username99'
Password: '123456'
`````
## Built With :hammer:
* <a href="https://dotnet.microsoft.com/download/dotnet/5.0"><img src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTYCy3Rpa06S-P_NqUnIpytPaJ7ctHu0soFNRtenHV_dNOuAdR-t4xPM4b7JkCZvSPaoHs&usqp=CAU" alt="ASP.NET 5 logo" width="30"><b>ASP.NET 5</b></a>
* <a href="https://entityframeworkcore.com/"><img src="https://z2c2b4z9.stackpathcdn.com/images/logo256X256.png" alt="Entity Framework Core Logo" width="30"><b>Entity Framework Core</b></a>
* <a href="https://www.microsoft.com/en-us/sql-server/sql-server-downloads"><img src="https://camo.githubusercontent.com/2fd20815f3b0a17768b1ee8429517c9f2e6ad5943681fbf09b8afed5fc72e306/68747470733a2f2f677265656e7769726569742e636f6d2f77702d636f6e74656e742f75706c6f6164732f323031332f30352f73716c2d7365727665722d65787072657373312e706e67" alt="Microsoft SQL Server Logo" width="30"><b>Microsoft SQL Server</b></a>
* <a href="https://developers.google.com/maps/documentation/javascript/places"><img src="https://developers.google.com/maps/images/maps-icon.svg" alt="Google places API" width="30"><b>Google Places API</b></a>
* <a href="https://getbootstrap.com"><img src="https://upload.wikimedia.org/wikipedia/commons/thumb/b/b2/Bootstrap_logo.svg/2560px-Bootstrap_logo.svg.png" alt="Bootstrap logo" width="30"><b>Bootstrap</b></a>
* <a href="https://jquery.com/"><img src="https://avatars.githubusercontent.com/u/70142?s=200&v=4" alt="JQuery" width="30"><b>jQuery</b></a>
* <a href="https://jquery.com/"><img src="https://upload.wikimedia.org/wikipedia/commons/thumb/6/61/HTML5_logo_and_wordmark.svg/1200px-HTML5_logo_and_wordmark.svg.png" alt="HTML5" width="30"><b>HTML5</b></a>
* <a href="https://developer.mozilla.org/en-US/docs/Web/CSS"><img src="https://upload.wikimedia.org/wikipedia/commons/d/d5/CSS3_logo_and_wordmark.svg" alt="CSS" width="30"><b>CSS</b></a>

## Overview :mag:
* Database diagram:
* <img src="https://i.ibb.co/XSLwWs6/diagram.jpg" alt="diagram" border="0">


