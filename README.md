# EasyFinance RESTfull Api
REST Service
with Swagger Documentation

### Add Advisor Example

~~~
{
	"Email": "Javier@mail.com",
	"Password":"123456",
	"Name":"Javier",
	"LastName": "Perez",
	"Gender": 1,
	"Description": "This is an example description",
	"Experience": 4,
	"University": "University",
	"Latitude": 12.1568141,
	"Longuitude": -72.123646
}
~~~
### Add Customer Example (Owner)

~~~
{
	"Email": "usuario@mail.com",
	"Password":"123456",
	"Gender": 1,
	"Birthday": "2000-01-12"
}
~~~
### Add Local Example (need to be authenticate with a Owner account)

~~~
{
	"Email": "Javier_local01@mail.com",
	"Password":"123456",
	"Name":"Javier",
	"LastName": "Perez",
	"Gender": 1,
	"Birthday": "2000-01-12"
}
~~~
### Authenticate Example

~~~
{
	"Email": "julio@gmail.com",
	"Password":"123456",
}
~~~
### Authorization Database Diagram

ALTER AUTHORIZATION ON DATABASE::EasyFinanceDb TO sa
GO

### Token example

https://jasonwatmore.com/post/2019/10/11/aspnet-core-3-jwt-authentication-tutorial-with-example-api
Update Registry Goal