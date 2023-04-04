# Important

Use npm install --force to set the front end project in case there are depencies conflicts
Use npm start to start the frontend

On the backend it is necessary to run an update-database after modifiying the connection string on the appSettings.

Web.Host should be selected as the starting project

The login is User: admin  Pass: 123qwe

# Introduction

This is program makes use of .Net Core 3 and Angular 11.

It also uses PrimeNg on the backend to include some features on the front and the EF on the bckend.

I made use  of Asp.Net Boilerplate to set the starting configurations of the system (login)
 
# Future implementation and what to do when no more rooms

Related to the no more rooms issue. Here, I assume that there are two different situations. Are there no more rooms available at the moment the user is trying to check in? Then we can implement a system of reservation or future booking based on the guest's check out dates available on the system.
The second situation is one in which there are no more rooms but there is also no way to create future bookings, let it be because of technical limitations or hotel policies.
On that case, the way to proceed will be an email or sms notification system on which we can fill out a form with the contacts of the customer. Then, every day, we can prepare a bulk email delivery and notify the to-be-guests that there are rooms available.
