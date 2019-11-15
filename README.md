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

### Article Example (Save & Update)

~~~
{
	"Title": "Articulo 11",
    "Body": "Este es el super articulo de prueba que deberia tener mas de 400 caracteres lo cual es bastante sin embargo se puede hacer esto escirbiendo todo lo que se piensa en ese momento. Hay que esperar que hasta este punto ya tenga 200 caracteres, pero uno nunca sabe, mejor sigo escribiendo un poco mas por si no se ha llegado a los 400 caracteres. supongo que ya deberia estar, procedere a contabilizarlo con el boton.",
    "Description": "Pequeña descripcion del articulo 11"
}
~~~

### Appointment Example (Save)

~~~
{
	"date": "2019-11-16T14:20:00"
}
~~~

### Authorization Database Diagram

ALTER AUTHORIZATION ON DATABASE::EasyFinanceDb TO sa
GO

### Token example

https://jasonwatmore.com/post/2019/10/11/aspnet-core-3-jwt-authentication-tutorial-with-example-api
Update Registry Goal