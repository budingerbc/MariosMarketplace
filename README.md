# Mario's Marketplace

#### .NET CRUD/DB/Unit Testing Project

##### By Ben Budinger

## Description

_A .NET site used for storing marketplace grocery products using a MySql database.  This project is mainly used for Unit Testing practice_

### Class Specifications

- Products
  * Name
  * Cost
  * Country of Origin
- Reviews
  * Author
  * ContentBody
  * Rating

###### Class Notes
1. Products will have a one to many relationship with reviews.
2. Reviews will have a 1 to 5 star rating.
3. An average review score can be viewed by clicking on a product to view its details.

### Site Navigation
- Landing page contains navigational tools for browsing the site
- Product list page containing all products in the database
- Each product can be clicked on to view details about it
- Products can be added, edited, and deleted
- Reviews can be added to a product

##### Future functionality desired

- TBD

### _How to use_ ###

1. Download project from GitHub: https://github.com/budingerbc/MariosMarketplace
2. Download and install MAMP
  * https://www.mamp.info/en/
  * This project/DB configuration is using port **8889**
  * In the MAMP preferences, change the MySQL Port to **8889**
  * Open the MAMP web start page and import the provided database
3. Build and run the project in Visual Studio
