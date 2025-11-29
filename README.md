# Product API

A complete Product Api for managing products with JWT authentication, built using the pure principles of the .NET 8 Web API.

## Features

- RESTful CRUD operations for products
- JWT-based authentication
- Advanced filtering, sorting, and layout
- Global exception handling
- CQRS model with separated DTOs
- Service layer architecture
- InMemory database with seeding
- Input validation
- Swagger documentation
- Comprehensive error handling

## Prerequisites

- .NET 8 SDK
- Preferred IDE (Visual Studio).

## How to Run

## Using the Command Line

1. Clone or Download the Project
If you don't have git installed. You need to install it first.
After installing it, you need to right-click to open git bash. Then you need to type
(git clone https://github.com/ElionKrasniqi0/ProductApi)
click on the project and open the solution file

Open ProductApi.sln in Visual Studio

Set as Startup Project

Right-click on the ProductApi project

Select "Set as Startup Project"
###################################################################################################################
2. Run the application

Press F5 or Ctrl + F5 to run
Accessing the Application

After running the application, you can access:
Swagger UI: https://localhost:7238/swagger/index.html
Database Initialization
The application uses an InMemory database that is automatically initialized with sample data when the application starts.
###################################################################################################################

##Sample data of sow
The database is preloaded with the following products:

ID	Name	Category	Price	Stock
1	Laptop	Electronics	$999.99	10
2	Book	Education	$29.99	100
3	Mouse	Electronics	$49.99	0
4	Desk	Furniture	$199.99	5
5	Chair	Furniture	$149.99	8
###################################################################################################################

3. When the application opens, an Authorization button appears. You need to press it and type: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiYWRtaW4iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBZG1pbiIsImV4cCI6MTc2NDQ2ODg5MywiaXNzIjoiUHJvZHVjdEFwaSIsImF1ZCI6IlByb2R1Y3RBcGlVc2VycyJ9.PEchBrfofBGEh3MU3gVqBEz2H663VzueCH1fmB_UHA4. There is no time to enter the Token. Below you can see: 
###################################################################################################################

##Auth:POST/api/Auth/login
Press it - Try it Out
A page opens and there you have to write:
json
{
"username": "admin",
"password": "password"
}
###################################################################################################################

##GET/api/products.
Category-Electronic,
Min Price-10
Max Price-100
SortBy-name
SortDescending-true
PageNumber-1
PageSize10
We can give these as we have them stored
###################################################################################################################

##POST/api/Products.

{
  "name": "Laptop",
  "category": "Electronics",
  "price": 299.99,
  "stockQuantity": 15
}
###################################################################################################################


##GET/api/Products/{id}
This is where the product ID is placed.
###################################################################################################################


##PUT/api/Products/{id}
This is where the product ID is placed.
and this
{
  "name": "Laptop",
  "category": "Electronic",
  "price": 0.01,
  "stockQuantity": 2147483647
}
###################################################################################################################


##DELETE/api/Products/{id}
This is where the product ID is placed.

###################################################################################################################

##Error Handling
The API includes comprehensive error handling:
400 Bad Request - Validation errors or invalid input
401 Unauthorized - Authentication required or invalid token
404 Not Found - Resource not found
500 Internal Server Error - Server-side errors
###################################################################################################################




